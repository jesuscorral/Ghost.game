using Ghost.Business.Interface;
using Ghost.Business.Interface.Dto;
using Ghost.Data.Interface;
using Ghost.Model.Ghost;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static Ghost.Service.Interface.Enums.Enum;

namespace Ghost.Business
{
    public class CheckWord : ICheckWord
    {
        private readonly IGhostRepository ghostRepository;

        public CheckWord(
             IGhostRepository ghostRepository)
        {
            this.ghostRepository = ghostRepository;
        }

        public string StartingWord { get; set; }
        
        public Player Turn { get; set; }

        public int Round { get; set; }

        public CheckWordDto Response { get; set; }

        public async Task<bool> ExecuteAsync()
        {
            Response = new CheckWordDto();

            var words = await this.ghostRepository.GetWordsAsync(StartingWord);

            IsValidWord(words.Count());

            // If the turn is corresponding to the human, the next turn will be for the computer.
            if (this.Turn == Player.Human)
            {
                // A list of winning words should be selected.
                var winningWords = SelectWinningWords(words);

                // If there are more than one word, choose on randomly.
                var nextLetter = winningWords.FirstOrDefault().WordValue.Substring(Round, 1);
                Response.Word = String.Concat(StartingWord, nextLetter);
            }

            // Populate response

            // Increment the round
            this.Response.Round = Round++;

            this.Response.Turn = this.Turn == Player.Human ? Player.Computer : Player.Human;
            
            return true;
        }

        /// <summary>
        /// Select the posible winning words for the computer. A winning word is a word with a odd number of letters.
        /// </summary>
        /// <param name="words">List of words</param>
        /// <returns>List of words with odd number of letters.</returns>
        private IEnumerable<Word> SelectWinningWords(IEnumerable<Word> words)
        {
            return words.Where((w) => w.WordValue.Length % 2 != 0 
                                        && w.WordValue.Length > this.Round).ToList();
        }
    
        private void IsValidWord(int wordsCount)
        {
            // If human add a letter that produces a string that cannot be extended into a word, the human lose
            if (wordsCount == 0 || wordsCount == 1)
            {
                this.Response.Winner = this.Turn == Player.Human ? Player.Computer : Player.Human;
            }
            else
            {
                this.Response.Winner = Player.None;
            }
        }
        
        public IList<ValidationResult> ValidationResults => throw new System.NotImplementedException();
    }
}