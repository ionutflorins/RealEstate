using RealEstateBussinesLogic.Interfaces.DeveloperLogic;
using RealEstateDAL.Context;
using RealEstateDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateBussinesLogic.DeveloperLogic
{
    public class DeveloperInsertCommand 
    {
        private RealEstateContext _dbContext;

        public DeveloperInsertCommand(RealEstateContext dbContext)
        {
            _dbContext = dbContext;
        }

        

    }
}
