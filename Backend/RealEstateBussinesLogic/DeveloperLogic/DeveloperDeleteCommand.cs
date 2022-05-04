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
    public class DeveloperDeleteCommand : IDeveloperDeleteCommand
    {
        private RealEstateContext _dbContext;

        public DeveloperDeleteCommand(RealEstateContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Delete(int developerID)
        {
            Developer developerExisting = null;

            using (var developerRep = new DeveloperRepository(_dbContext))
            {
                 developerExisting = developerRep
                    .GetWhere(x => x.ID == developerID)
                    .FirstOrDefault();
                if (developerExisting == null)
                {
                    return 0;
                }

                developerRep.Delete(developerExisting);
                _dbContext.SaveChanges();
            }
            return developerExisting.ID;
        }
    }
}
