using Microsoft.EntityFrameworkCore;
using RealEstateBussinesLogic.Interfaces.DeveloperLogic;
using RealEstateBussinesLogic.Models.Developer;
using RealEstateDAL.Context;
using RealEstateDAL.Entities;
using RealEstateDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateBussinesLogic.DeveloperLogic
{
    public class DeveloperUpdateCommand : IDeveloperUpdateCommand
    {
        private RealEstateContext _dbContext;

        public DeveloperUpdateCommand(RealEstateContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Edit(DeveloperEdit developerEdit)
        {
            Developer developerExisting = null;
            using (var developerRep = new DeveloperRepository(_dbContext))
            {
                 developerExisting = developerRep
                    .GetWhere(d => d.ID == developerEdit.ID)
                    .FirstOrDefault();

                if (developerExisting == null)
                {
                    return 0;
                }

                developerExisting.Name = developerEdit.Name;
                developerExisting.PhoneNumber = developerEdit.PhoneNumber;
                developerExisting.Email = developerEdit.Email;
                developerExisting.City = developerEdit.City;
                developerExisting.Address = developerEdit.Address;
                developerExisting.ZipCode = developerEdit.ZipCode;

                developerRep.Update(developerExisting);
                _dbContext.SaveChanges();
            }
            return developerExisting.ID;

        }
    }
}
