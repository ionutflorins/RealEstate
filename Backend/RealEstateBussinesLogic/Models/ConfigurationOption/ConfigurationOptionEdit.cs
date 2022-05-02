using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateBussinesLogic.Models.ConfigurationOption
{
    public class ConfigurationOptionEdit
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public int ConfigurationItemId { get; set; }

    }
}
