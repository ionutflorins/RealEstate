using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDAL.Entities
{
    public class PropertyConfiguration
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(100)]
        public string FormNumber { get; set; }
        public int ContractID { get; set; }
        public Contract Contract { get; set; }
        public PropertyConfigurationItems PropertyConfigurationItems { get; set; }
    }
}
