using static Ghost.Service.Interface.Enums.Enum;

namespace Ghost.Service.Interface.Request
{
    public class CheckWordRequest
    {
        public string HumanWord { get; set; }

        public string ComputedWord { get; set; }

        public Player Turn { get; set; }

        public string LetterTyped { get; set; }
       
        public int Round { get; set; }
    }
}