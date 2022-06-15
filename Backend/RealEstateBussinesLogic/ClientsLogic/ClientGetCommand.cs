using RealEstateBussinesLogic.Interfaces.ClientLogic;
using RealEstateBussinesLogic.Models.Client;
using RealEstateBussinesLogic.Models.Developer;
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
                .Select( x => new ClientListView { ID = x.ID, FirstName= x.FirstName, LastName = x.LastName, PhoneNumber = x.PhoneNumber, PersonalID = x.PersonalID, SerieNo = x.SerieNo, Address = x.Address, IssuedBy = x.IssuedBy, Validity = x.Validity, DeveloperID = x.DeveloperID, AppUserID = x.AppUserID })
                .ToList();
            return clientListModel;
        }

        public IList<ClientListView> GetClientsDev(int devID)
        {
            var clientRep = new ClientRepository(_dbContext);
            var clientList = clientRep.GetAll();
            var clientListModel = clientList
                .Select(x => new ClientListView { ID = x.ID, FirstName = x.FirstName, LastName = x.LastName, PhoneNumber = x.PhoneNumber, PersonalID = x.PersonalID, SerieNo = x.SerieNo, Address = x.Address, IssuedBy = x.IssuedBy, Validity = x.Validity, DeveloperID = x.DeveloperID, AppUserID = x.AppUserID })
                .Where(x=> x.DeveloperID == devID)
                .ToList();
            return clientListModel;
        }

        public IList<ClientListView> GetClientsbyUserId(string userID)
        {
            var clientRep = new ClientRepository(_dbContext);
            var clientList = clientRep.GetAll();
            var clientListModel = clientList
                .Select(x => new ClientListView { ID = x.ID, FirstName = x.FirstName, LastName = x.LastName, PhoneNumber = x.PhoneNumber, PersonalID = x.PersonalID, SerieNo = x.SerieNo, Address = x.Address, IssuedBy = x.IssuedBy, Validity = x.Validity, DeveloperID = x.DeveloperID, AppUserID = x.AppUserID })
                .Where(x => x.AppUserID == userID)
                .ToList();
            return clientListModel;
        }
    }
}
