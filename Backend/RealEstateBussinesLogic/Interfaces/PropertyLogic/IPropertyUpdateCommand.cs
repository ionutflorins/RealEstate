using RealEstateBussinesLogic.Models.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateBussinesLogic.Interfaces.PropertyLogic
{
    public interface IPropertyUpdateCommand
    {
        int Edit(PropertyEdit propertyEdit);
    }
}
