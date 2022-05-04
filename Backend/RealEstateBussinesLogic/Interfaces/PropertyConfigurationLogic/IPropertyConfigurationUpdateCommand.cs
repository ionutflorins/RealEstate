using RealEstateBussinesLogic.Models.PropertyConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateBussinesLogic.Interfaces.PropertyConfigurationLogic
{
    public interface IPropertyConfigurationUpdateCommand
    {
        int Update(PropertyConfigurationEdit propertyConfigurationEdit);
    }
}
