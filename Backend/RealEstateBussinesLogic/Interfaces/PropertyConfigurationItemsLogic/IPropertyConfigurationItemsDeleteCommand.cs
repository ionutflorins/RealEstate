using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateBussinesLogic.Interfaces.PropertyConfigurationItemsLogic
{
    public interface IPropertyConfigurationItemsDeleteCommand
    {
        int Delete(int propertyConfigItemsID);
    }
}
