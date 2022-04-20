using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateDAL.Entities
{
    public class Property
    {
        public int ID { get; set; }
        [MaxLength(100)]
        [Required]
        public string Type { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        [Required]
        public int RoomNo { get; set; }
        [MaxLength(50)]
        [Required]
        public string IdentityNo { get; set; }
        [MaxLength(50)]
        [Required]
        public string BuildingNo { get; set; }
        [MaxLength(50)]
        [Required]
        public string PropertySqm { get; set; }
        [MaxLength(50)]
        [Required]
        public string? LotSqm { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public Project Project { get; set; }
        public Contract Contract { get; set; }

    }
}
