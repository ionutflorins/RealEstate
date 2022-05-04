using RealEstateBussinesLogic.Models.Developer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateBussinesLogic.Interfaces.DeveloperLogic
{
    public interface IDeveloperUpdateCommand
    {
         int Edit(DeveloperEdit developerEdit);
    }
}
