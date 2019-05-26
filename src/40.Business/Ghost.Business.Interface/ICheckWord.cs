using Ghost.Business.Interface.Dto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using static Ghost.Service.Interface.Enums.Enum;

namespace Ghost.Business.Interface
{
    public interface ICheckWord
    {
        string StartingWord { get; set; }
        
        Player Turn { get; set; }

        int Round { get; set; }

        CheckWordDto Response { get; set; }

        Task<bool> ExecuteAsync();

        IList<ValidationResult> ValidationResults { get; }
    }
}