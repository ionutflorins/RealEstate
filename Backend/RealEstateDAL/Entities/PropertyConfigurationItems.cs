using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDAL.Entities
{
    public class PropertyConfigurationItems
    {
        public int ID { get; set; }
        public int PropertyConfigurationID { get; set; }
        public PropertyConfiguration PropertyConfiguration { get; set; }
        public int ConfigurationItemID { get; set; }
        public ConfigurationItem ConfigurationItem { get; set; }
        public int ConfigurationOptionID { get; set; }
        public ConfigurationOption ConfigurationOption { get; set; }

    }
}
