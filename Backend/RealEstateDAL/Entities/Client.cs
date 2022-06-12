using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateDAL.Entities
{
    public class Client
    {
        public int ID { get; set; }
        [MaxLength(100)]
        [Required]
        public string FirstName { get; set; }
        [MaxLength(100)]
        [Required]
        public string LastName { get; set; }
        [MaxLength(20)]
        [Required]
        public string PhoneNumber { get; set; }
        [MaxLength(50)]
        [Required]
        public string PersonalID { get; set; }
        [MaxLength(50)]
        [Required]
        public string SerieNo { get; set; }
        [MaxLength(250)]
        [Required]
        public string Address { get; set; }
        [MaxLength(50)]
        [Required]
        public string IssuedBy { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Validity { get; set; }
        public string AppUserID { get; set; }
        public virtual AppUser AppUser { get; set; }
        public int DeveloperID { get; set; }
        public Developer Developer { get; set; }
        public ICollection<Contract> Contract { get; set; }
    }
}
