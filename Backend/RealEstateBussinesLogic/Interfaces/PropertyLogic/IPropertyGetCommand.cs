using RealEstateBussinesLogic.Models.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateBussinesLogic.Interfaces.PropertyLogic
{
    public interface IPropertyGetCommand
    {
        IList<PropertyListView> GetAllProperty();
        IList<PropertyListView> GetPropertyByProj(int projID);
    }
}
