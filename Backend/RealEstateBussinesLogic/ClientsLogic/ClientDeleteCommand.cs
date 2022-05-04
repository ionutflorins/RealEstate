using RealEstateBussinesLogic.Interfaces.ClientLogic;
using RealEstateDAL.Context;
using RealEstateDAL.Entities;
using RealEstateDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateBussinesLogic.ClientsLogic
{
    public class ClientDeleteCommand : IClientDeleteCommand
    {
        private RealEstateContext _dbContext;

        public ClientDeleteCommand(RealEstateContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Delete(int clientID)
        {
            Client clientExisting = null;
            using (var clientRep = new ClientRepository(_dbContext))
            {
               clientExisting = clientRep
                    .GetWhere(d => d.ID == clientID)
                    .FirstOrDefault();
                if(clientExisting == null)
                {
                    return 0;
                }

                clientRep.Delete(clientExisting);
                _dbContext.SaveChanges();
            }
            return clientExisting.ID;
        }
    }
}
