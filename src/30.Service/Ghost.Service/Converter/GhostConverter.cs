using AutoMapper;
using Ghost.Model.Ghost;
using Ghost.Service.Interface.Dto;

namespace Ghost.Service.Converter
{
    public class GhostConverter : Profile
    {
        public GhostConverter()
        {
            // Map word to wordDto and viceversa
            CreateMap<Word, WordDto>().ReverseMap();
        }
    }
}
