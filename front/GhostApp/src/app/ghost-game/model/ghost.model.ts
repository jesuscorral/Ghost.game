import { PlayerEnum } from '../enum/ghost.enum';

export class GhostData {
  private word: string;
  private turn: PlayerEnum;
  private round: number;

  constructor(word: string, turn: PlayerEnum, round: number) {
    this.word = word;
    this.turn = turn;
    this.round = round;
  }

  get Word(): string {
    return this.word;
  }

  set Word(word: string) {
    this.word = word;
  }

  get Turn(): PlayerEnum {
    return this.turn;
  }

  set Turn(turn: PlayerEnum) {
    this.turn = turn;
  }

  get Round(): number {
    return this.round;
  }

  set Round(round: number) {
    this.round = round;
  }
}
