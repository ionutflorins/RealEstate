using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDAL.Entities
{
    public class ConfigurationOption
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public int ConfigurationItemId { get; set; }
        public ConfigurationItem ConfigurationItem { get; set; }
        public PropertyConfigurationItems PropertyConfigurationItems { get; set; }

    }
}
