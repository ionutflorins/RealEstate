using RealEstateBussinesLogic.Models.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateBussinesLogic.Interfaces.ProjectLogic
{
    public interface IProjectUpdateCommand
    {
        int Update(ProjectEdit projectEdit);
    }
}
