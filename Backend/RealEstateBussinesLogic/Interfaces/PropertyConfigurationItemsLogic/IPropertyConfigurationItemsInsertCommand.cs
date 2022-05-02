using RealEstateBussinesLogic.Models.PropertyConfigurationItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateBussinesLogic.Interfaces.PropertyConfigurationItemsLogic
{
    public interface IPropertyConfigurationItemsInsertCommand
    {
        int Add(PropertyConfigurationItemsEdit propertyConfigurationItemsEdit);
    }
}
