using static Ghost.Service.Interface.Enums.Enum;

namespace Ghost.Business.Interface.Dto
{
    public class CheckWordDto
    {
        public Player Winner { get; set; }

        public Player Turn { get; set; }

        public int Round { get; set; }

        public string Word { get; set; }
    }
}
