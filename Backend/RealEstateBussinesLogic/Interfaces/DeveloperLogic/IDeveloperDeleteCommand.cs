using RealEstateBussinesLogic.Models.Developer;
using RealEstateDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateBussinesLogic.Interfaces.DeveloperLogic
{
    public interface IDeveloperDeleteCommand
    {
        int Delete(int developerID);
    }
}
