using static Ghost.Service.Interface.Enums.Enum;

namespace Ghost.Service.Interface.Response
{
    public class CheckWordResponse
    {
        public Player Winner { get; set; }

        public Player Turn { get; set; }

        public int Round { get; set; }

        public string Word { get; set; }
    }
}
