using System.ComponentModel.DataAnnotations;

namespace RealEstateDAL.Entities
{
    public class Developer
    {
        public int ID { get; set; }
        [MaxLength(200)]
        [Required]
        public string Name { get; set; } = String.Empty;
        [MaxLength(20)]
        [Required]
        public string PhoneNumber { get; set; } = String.Empty;
        [MaxLength(150)]
        [Required]
        public string Email { get; set; } = String.Empty;
        [MaxLength(100)]
        [Required]
        public string City { get; set; } = String.Empty;
        [MaxLength(250)]
        [Required]
        public string Address { get; set; } = String.Empty;
        [MaxLength(50)]
        [Required]
        public string ZipCode { get; set; } = String.Empty;

        public ICollection<Contract> Contracts { get; set; }
    }
}
