using System.ComponentModel.DataAnnotations;

namespace VailaPlace.Models.Dto
{
    public class VailaNumberUpdateDto
    {
        [Required]
        public int VailaNo { get; set; }
        [Required]
        public int VailaId { get; set; }
        [Required]
        public string SpecialDetails { get; set; }
    }
}