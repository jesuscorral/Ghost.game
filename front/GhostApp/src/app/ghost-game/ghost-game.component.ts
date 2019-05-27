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

  constructor(private service: GhostService) { }

  ngOnInit() {

    let g: GhostData = new GhostData('aa', 'aa', PlayerEnum.Human, 'a', 1);
    this.service.checkWord(g);
  }

}
