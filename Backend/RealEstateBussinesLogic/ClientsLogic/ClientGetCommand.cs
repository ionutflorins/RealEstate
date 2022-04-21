using RealEstateBussinesLogic.Interfaces.ClientLogic;
using RealEstateBussinesLogic.Models.Client;
using RealEstateDAL.Context;
using RealEstateDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateBussinesLogic.ClientsLogic
{
    public class ClientGetCommand : IClientGetCommand
    {
        private RealEstateContext _dbContext;
        public ClientGetCommand(RealEstateContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<ClientListView> GetAllClients()
        {
            var clientRep = new ClientRepository(_dbContext);
            var clientList = clientRep.GetAll();
            var clientListModel = clientList
                .Select( x => new ClientListView { ID = x.ID, Name= x.FirstName})
                .ToList();

            return clientListModel;
        }
    }
}
