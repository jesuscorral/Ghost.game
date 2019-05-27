using static Ghost.Service.Interface.Enums.Enum;

namespace Ghost.Service.Interface.Request
{
    public class CheckWordRequest
    {
        public string Word { get; set; }

        public Player Turn { get; set; }
               
        public int Round { get; set; }
    }
}