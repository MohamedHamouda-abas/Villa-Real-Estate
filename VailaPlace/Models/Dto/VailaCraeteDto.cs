using System.ComponentModel.DataAnnotations;

namespace VailaPlace.Models.Dto
{
    public class VailaCraeteDto
    {      
        [MaxLength(100, ErrorMessage = "Please inter a name short than 100 word")]
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
