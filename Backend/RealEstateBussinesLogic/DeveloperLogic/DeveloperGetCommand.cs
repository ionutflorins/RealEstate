using RealEstateBussinesLogic.Interfaces.DeveloperLogic;
using RealEstateBussinesLogic.Models.Developer;
using RealEstateDAL.Context;
using RealEstateDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateBussinesLogic.DeveloperLogic
{
    public class DeveloperGetCommand : IDeveloperGetCommand
    {
        private RealEstateContext _dbContext;

        public DeveloperGetCommand(RealEstateContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<DeveloperListView> GetAllDevelopers()
        {
            var developerRep = new DeveloperRepository(_dbContext);
            var developerList = developerRep.GetAll();
            var clientListModel = developerList
                .Select(x => new DeveloperListView { ID = x.ID, Name = x.Name, Address = x.Address, City = x.City, PhoneNumber = x.PhoneNumber, Email = x.Email, ZipCode = x.ZipCode })
                .ToList();

            return clientListModel;

        }
    }
}
    
