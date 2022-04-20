using System.ComponentModel.DataAnnotations;

namespace RealEstateDAL.Entities
{
    public class Project
    {

        public int ID { get; set; }

        [MaxLength(200)]
        [Required]
        public string ProjectName { get; set; } = string.Empty;
        [MaxLength(150)]
        [Required]
        public string City { get; set; } = string.Empty;
        [MaxLength(200)]
        [Required]
        public string Address { get; set; } = string.Empty;
        [Required]
        public int? BuildingsNo { get; set; }
        [Required]
        public int? ApartmentNo { get; set; }
        [Required]
        public int? HouseNo { get; set; }
        [MaxLength(500)]
        [Required]
        public string Description { get; set; } = string.Empty;
        public Developer Developer { get; set; }
    }
}
