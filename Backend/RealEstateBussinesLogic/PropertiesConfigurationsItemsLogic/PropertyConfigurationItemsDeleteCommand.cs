using RealEstateBussinesLogic.Interfaces.PropertyConfigurationItemsLogic;
using RealEstateDAL.Context;
using RealEstateDAL.Entities;
using RealEstateDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateBussinesLogic.PropertiesConfigurationsItemsLogic
{
    public class PropertyConfigurationItemsDeleteCommand : IPropertyConfigurationItemsDeleteCommand
    {
        private RealEstateContext _dbContext;

        public PropertyConfigurationItemsDeleteCommand(RealEstateContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Delete(int propertyConfigItemsID)
        {
            PropertyConfigurationItems propertyConfigItemsExisting = null;

            using (var propertyConfigItemsRep = new PropertyConfigurationItemsRepository(_dbContext))
            {
                propertyConfigItemsExisting = propertyConfigItemsRep
                   .GetWhere(x => x.ID == propertyConfigItemsID)
                   .FirstOrDefault();
                if (propertyConfigItemsExisting == null)
                {
                    return 0;
                }

                propertyConfigItemsRep.Delete(propertyConfigItemsExisting);
                _dbContext.SaveChanges();
            }
            return propertyConfigItemsExisting.ID;
        }
    }
}
