using RealEstateBussinesLogic.Models.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateBussinesLogic.Interfaces.ClientLogic
{
    public interface IClientGetCommand
    {
        IList<ClientListView> GetAllClients();


    }
}
