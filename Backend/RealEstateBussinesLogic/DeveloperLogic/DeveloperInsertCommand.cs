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
    public class DeveloperInsertCommand : IDeveloperInsertCommand
    {
        private RealEstateContext _dbContext;

        public DeveloperInsertCommand(RealEstateContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Add(DeveloperEdit developerEdit)
        {
            var developer = new Developer();
            var developerRep = new DeveloperRepository(_dbContext);
            var developerExisting = developerRep
                .GetWhere(d => d.Name == developerEdit.Name)
                .ToList();
            
            developer.Name = developerEdit.Name;
            developer.PhoneNumber = developerEdit.PhoneNumber;
            developer.Email = developerEdit.Email;
            developer.City = developerEdit.City;
            developer.Address = developerEdit.Address;
            developer.ZipCode = developerEdit.ZipCode;
            developer.AppUserID = developerEdit.AppUserID;

            if (developerExisting == null || developerExisting.Count <= 0 )
            {

                developerRep.Insert(developer);
                _dbContext.SaveChanges();
            }
            return developer.ID;
        }
    }
}
