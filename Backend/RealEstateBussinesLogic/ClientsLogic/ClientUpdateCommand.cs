using RealEstateBussinesLogic.Interfaces.ClientLogic;
using RealEstateBussinesLogic.Models.Client;
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
    public class ClientUpdateCommand : IClientUpdateCommand
    {
        private RealEstateContext _dbContext;

        public ClientUpdateCommand(RealEstateContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Edit(ClientEdit clientEdit)
        {
            Client clientExisting = null;
            using (var clientRep = new ClientRepository(_dbContext))
            {
                clientExisting = clientRep
                    .GetWhere(d => d.ID == clientEdit.ID)
                    .FirstOrDefault();

                if (clientExisting == null)
                {
                    return 0;
                }

                clientExisting.FirstName = clientEdit.FirstName;
                clientExisting.LastName = clientEdit.LastName;
                clientExisting.PhoneNumber = clientEdit.PhoneNumber;
                clientExisting.PersonalID = clientEdit.PersonalID;
                clientExisting.SerieNo = clientEdit.SerieNo;
                clientExisting.Address = clientEdit.Address;
                clientExisting.IssuedBy = clientEdit.IssuedBy;
                clientExisting.Validity = clientEdit.Validity;
                clientExisting.DeveloperID = clientEdit.DeveloperID;

                clientRep.Update(clientExisting);
                _dbContext.SaveChanges();
            }
            return clientExisting.ID;

        }
    }
}
