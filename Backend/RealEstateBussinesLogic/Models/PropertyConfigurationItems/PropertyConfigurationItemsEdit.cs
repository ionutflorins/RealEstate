using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateBussinesLogic.Models.PropertyConfigurationItems
{
    public class PropertyConfigurationItemsEdit
    {
        public int ID { get; set; }
        public int PropertyConfigurationID { get; set; }
        public int ConfigurationItemID { get; set; }
        public int ConfigurationOptionID { get; set; }
    }
}
