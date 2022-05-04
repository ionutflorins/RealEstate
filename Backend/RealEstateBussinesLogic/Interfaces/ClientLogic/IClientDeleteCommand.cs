using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateBussinesLogic.Interfaces.ClientLogic
{
    public interface IClientDeleteCommand
    {
        int Delete(int ClientID);
    }
}
