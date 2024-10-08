using System.ComponentModel.DataAnnotations;

namespace MagicVila_Web.Models.Dto
{
    public class VailaDto
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100, ErrorMessage = "Please inter a name short than 100 word")]
        [Required]
        public string Name { get; set; }
        public double Area { get; set; }
        public int Occupancy { get; set; }
        public double Rate { get; set; }
        public int sqft { get; set; }
        public string Details { get; set; }
        public string ImageUrl { get; set; }
        public string Amenity { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
