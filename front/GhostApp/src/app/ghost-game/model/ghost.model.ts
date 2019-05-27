import { PlayerEnum } from '../enum/ghost.enum';

export class GhostData {
  private humanWord: string;
  private computerWord: string;
  private turn: PlayerEnum;
  private letterTyped: string;
  private round: number;

  constructor(humanWord: string, computerWord: string, turn: PlayerEnum, letterTyped: string, round: number) {
    this.humanWord = humanWord,
    this.computerWord = computerWord;
    this.turn = turn;
    this.letterTyped = letterTyped;
    this.round = round;
  }

  get HumanWord(): string {
    return this.humanWord;
  }

  set HumanWord(humanWord: string) {
    this.humanWord = humanWord;
  }

  get ComputerWord(): string {
    return this.computerWord;
  }

  set ComputerWord(computerWord: string) {
    this.computerWord = computerWord;
  }

  get Turn(): PlayerEnum {
    return this.turn;
  }

  set Turn(turn: PlayerEnum) {
    this.turn = turn;
  }

  get LetterTyped(): string {
    return this.letterTyped;
  }
  set LetterTyped(letterTyped: string) {
    this.letterTyped = letterTyped;
  }

  get Round(): number {
    return this.round;
  }

  set Round(round: number) {
    this.round = round;
  }
}
