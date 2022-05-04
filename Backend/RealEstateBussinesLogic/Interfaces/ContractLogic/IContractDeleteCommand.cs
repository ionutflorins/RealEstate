using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateBussinesLogic.Interfaces.ContractLogic
{
    public interface IContractDeleteCommand
    {
        int Delete(int contractID);
    }
}
