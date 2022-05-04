using RealEstateBussinesLogic.Models.ConfigurationOption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateBussinesLogic.Interfaces.ConfigurationOptionLogic
{
    public interface IConfigurationOptionUpdateCommand
    {
        int Update(ConfigurationOptionEdit configurationOptionEdit);
    }
}
