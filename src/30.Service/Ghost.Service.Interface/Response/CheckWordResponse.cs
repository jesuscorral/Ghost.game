using Ghost.Service.Interface.Dto;
using System.Collections.Generic;

namespace Ghost.Service.Interface.Response
{
    public class CheckWordResponse
    {
        public IEnumerable<WordDto> Words { get; set; }
    }
}
