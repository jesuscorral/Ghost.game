import { Component, OnInit } from '@angular/core';
import { GhostService } from '../services/ghost.service';
import { PlayerEnum } from './enum/ghost.enum';
import { GhostData } from './model/ghost.model';

@Component({
  selector: 'app-ghost-game',
  templateUrl: './ghost-game.component.html',
  styleUrls: ['./ghost-game.component.css']
})
export class GhostGameComponent implements OnInit {

  writeLetterDisable = true;
  newRoundButtonDisable = false;
  isLoadingResults = false;
  winner = PlayerEnum.None;
  winnerMessage = '';
  round = 1;
  turn = PlayerEnum.Human;
  word = '';

  constructor(private service: GhostService) { }

  ngOnInit() {

  }

  onSendLetter() {
    this.writeLetterDisable = true;
    this.isLoadingResults = true;
    const g: GhostData = new GhostData(this.word, PlayerEnum.Human, this.round);
    let checkWordResponse: any = null;

    this.service.checkWord(g)
      .subscribe(data  => {
        checkWordResponse = data;

        if (checkWordResponse != null) {
          this.word = checkWordResponse.Word;
          this.isLoadingResults = false;
          this.writeLetterDisable = false;
          this.round = checkWordResponse.round + 1;
          if (checkWordResponse.Winner !== PlayerEnum.None) {
            this.writeLetterDisable = true;
            this.newRoundButtonDisable = false;
            this.winnerMessage = 'The winner is:' + checkWordResponse.Winner.toString();
          }
        }
      }, (error)  => {
      console.log('Error', error);
      }
    );

    if (checkWordResponse != null) {
      this.word = checkWordResponse.Word;

      if (checkWordResponse.Winner !== PlayerEnum.None) {
        this.writeLetterDisable = true;
        this.newRoundButtonDisable = true;
        this.winnerMessage = checkWordResponse.Winner.toString();
      }
    }

  }

  onNewRound() {
   this.writeLetterDisable = false;
   this.isLoadingResults = false;
   this.round = 1;
   this.turn = PlayerEnum.Human;
   this.word = '';
   this.winner = PlayerEnum.None;
  }
}
