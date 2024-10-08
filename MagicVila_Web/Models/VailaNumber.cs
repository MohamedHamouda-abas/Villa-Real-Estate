using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicVila_Web.Models
{
    public class VailaNumber
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VailaNo { get; set; }
        public string SpecialDetails { get; set; }
        [ForeignKey("Vaila")]
        public int VailaId { get; set; }
        public Vaila Vaila { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
