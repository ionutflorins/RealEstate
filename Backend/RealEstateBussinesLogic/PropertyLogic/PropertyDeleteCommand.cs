using RealEstateBussinesLogic.Interfaces.PropertyLogic;
using RealEstateDAL.Context;
using RealEstateDAL.Entities;
using RealEstateDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateBussinesLogic.PropertyLogic
{
    public class PropertyDeleteCommand : IPropertyDeleteCommand
    {
        private RealEstateContext _dbContext;

        public PropertyDeleteCommand(RealEstateContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Delete(int propertyID)
        {
            Property propertyExisting = null;

            using (var propertyRep = new PropertyRepository(_dbContext))
            {
                propertyExisting = propertyRep
                   .GetWhere(x => x.ID == propertyID)
                   .FirstOrDefault();
                if (propertyExisting == null)
                {
                    return 0;
                }

                propertyRep.Delete(propertyExisting);
                _dbContext.SaveChanges();
            }
            return propertyExisting.ID;
        }
    }
}


