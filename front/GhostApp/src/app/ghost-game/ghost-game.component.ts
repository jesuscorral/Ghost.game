import { Component, OnInit } from '@angular/core';
import { GhostService } from '../services/ghost.service';
import { PlayerEnum } from './enum/ghost.enum';
import { GhostData } from './model/ghost.model';
import { CheckWordDto } from './model/check-word-response.model';

@Component({
  selector: 'app-ghost-game',
  templateUrl: './ghost-game.component.html',
  styleUrls: ['./ghost-game.component.css']
})
export class GhostGameComponent implements OnInit {

  writeLetterDisable = true;
  newRoundButtonDisable = false;
  isLoadingResults = false;
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
    let checkWord: CheckWordDto = null;

    this.service.checkWord(g)
      .subscribe(data  => {
        checkWord = data;
        this.isLoadingResults = false;
      }, (error)  => {
      console.log('Error', error);
      }
    );
  }

  onNewRound() {
   this.writeLetterDisable = false;
   this.round = 1;
   this.turn = PlayerEnum.Human;
   this.word = '';
  }
}
