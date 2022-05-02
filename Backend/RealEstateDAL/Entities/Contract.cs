using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateDAL.Entities
{
    public class Contract
    {
        public int ID { get; set; }
        [Required]
        public string ContractNumber { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }
        public int ClientID { get; set; }
        public Client Client { get; set; }
        public int? PropertyID { get; set; }
        public Property Property { get; set; }
        public int DeveloperID { get; set; }
        public Developer Developer { get; set; }
        public PropertyConfiguration Configuration { get; set; }

    }
}
