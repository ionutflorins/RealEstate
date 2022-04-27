using RealEstateBussinesLogic.Models.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateBussinesLogic.Interfaces.ContractLogic
{
    public interface IContractGetCommand
    {
        IList<ContractListView> GetAllContract();
    }
}
