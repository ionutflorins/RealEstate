using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateBussinesLogic.Interfaces.ConfigurationOptionLogic
{
    public interface IConfigurationOptionDeleteCommand
    {
        int Delete(int ConfigurationOptionID);
    }
}
