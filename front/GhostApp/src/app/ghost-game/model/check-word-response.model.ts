import { PlayerEnum } from '../enum/ghost.enum';

export class CheckWordDto {
  private winner: PlayerEnum;
  private turn: PlayerEnum;
  private word: string;
  private round: number;

  constructor( winner: PlayerEnum, turn: PlayerEnum, word: string, round: number) {
    this.winner = winner;
    this.turn = turn;
    this.word = word;
    this.round = round;
  }

  get Winner(): PlayerEnum {
    return this.winner;
  }

  set Winner(winner: PlayerEnum) {
    this.winner = winner;
  }

  get Turn(): PlayerEnum {
    return this.turn;
  }

  set Turn(turn: PlayerEnum) {
    this.turn = turn;
  }

  get Word(): string {
    return this.word;
  }

  set Word(word: string) {
    this.word = word;
  }

  get Round(): number {
    return this.round;
  }

  set Round(round: number) {
    this.round = round;
  }
  }
