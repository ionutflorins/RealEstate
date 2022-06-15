using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDAL.Entities
{
    public class ConfigurationItem
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public ICollection<ConfigurationOption> ConfigurationOption { get; set; }
        public ICollection<PropertyConfigurationItems> PropertyConfigurationItems { get; set; }
    }
}
