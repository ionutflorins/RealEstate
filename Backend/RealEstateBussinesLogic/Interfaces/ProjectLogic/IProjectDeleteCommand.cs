using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateBussinesLogic.Interfaces.ProjectLogic
{
    public interface IProjectDeleteCommand
    {
        int Delete(int projectID);
    }
}
