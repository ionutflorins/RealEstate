using RealEstateBussinesLogic.Interfaces.PropertyConfigurationItemsLogic;
using RealEstateBussinesLogic.Models.PropertyConfigurationItems;
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
    public class PropertyConfigurationItemsUpdateCommand : IPropertyConfigurationItemsUpdateCommand
    {
        private RealEstateContext _dbContext;

        public PropertyConfigurationItemsUpdateCommand(RealEstateContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Update(PropertyConfigurationItemsEdit propertyConfigurationItemsEdit)
        {
            PropertyConfigurationItems propertyConfigurationItemsExisting = null;
            using (var propertyConfigurationItemsRep = new PropertyConfigurationItemsRepository(_dbContext))
            {
                propertyConfigurationItemsExisting = propertyConfigurationItemsRep
                   .GetWhere(d => d.ID == propertyConfigurationItemsEdit.ID)
                   .FirstOrDefault();

                if (propertyConfigurationItemsExisting == null)
                {
                    return 0;
                }

                propertyConfigurationItemsExisting.PropertyConfigurationID = propertyConfigurationItemsEdit.PropertyConfigurationID;
                propertyConfigurationItemsExisting.ConfigurationItemID = propertyConfigurationItemsEdit.ConfigurationItemID;
                propertyConfigurationItemsExisting.ConfigurationOptionID = propertyConfigurationItemsEdit.ConfigurationOptionID;

                propertyConfigurationItemsRep.Update(propertyConfigurationItemsExisting);
                _dbContext.SaveChanges();
            }
            return propertyConfigurationItemsExisting.ID;

        }
    }
}
