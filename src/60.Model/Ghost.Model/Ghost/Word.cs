using System.ComponentModel.DataAnnotations;

namespace Ghost.Model.Ghost
{
    public class Word : BaseEntity
    {
        [Required]
        [MaxLength(50)]    
        public string WordValue { get; set; }
    }
}