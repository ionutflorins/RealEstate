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
    public class ClientInsertCommand : IClientInsertCommand
    {
        private RealEstateContext _dbContext;

        public ClientInsertCommand(RealEstateContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Add(ClientEdit clientEdit)
        {
            var client = new Client();
            var clientRep = new ClientRepository(_dbContext);
            var clientExisting = clientRep
                .GetWhere(d => d.PersonalID == clientEdit.PersonalID)
                .ToList();
            client.ID = clientEdit.ID;
            client.FirstName = clientEdit.FirstName;
            client.LastName = clientEdit.LastName;
            client.PhoneNumber = clientEdit.PhoneNumber;
            client.PersonalID = clientEdit.PersonalID;
            client.SerieNo = clientEdit.SerieNo;
            client.Address = clientEdit.Address;
            client.IssuedBy = clientEdit.IssuedBy;
            client.Validity = clientEdit.Validity;

            if(clientExisting == null || clientExisting.Count <= 0)
            {
                clientRep.Insert(client);
                _dbContext.SaveChanges();
            }
            return client.ID;
        }

    }
}
