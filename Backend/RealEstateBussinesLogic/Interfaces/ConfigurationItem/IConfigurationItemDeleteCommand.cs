﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateBussinesLogic.Interfaces.ConfigurationItem
{
    public interface IConfigurationItemDeleteCommand
    {
        int Delete(int configurationItemID);
    }
}
