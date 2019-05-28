import { PlayerEnum } from '../enum/ghost.enum';

export class CheckWordDto {
  public winner: PlayerEnum;
  public turn: PlayerEnum;
  public word: string;
  public round: number;

  constructor( playerWinner: PlayerEnum, playerTurn: PlayerEnum, wordWrite: string, roundNumber: number) {
    this.winner = playerWinner;
    this.turn = playerTurn;
    this.word = wordWrite;
    this.round = roundNumber;
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
