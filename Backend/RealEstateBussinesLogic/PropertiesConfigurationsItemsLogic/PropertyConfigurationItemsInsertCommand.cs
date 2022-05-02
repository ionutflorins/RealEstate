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
    public class PropertyConfigurationItemsInsertCommand : IPropertyConfigurationItemsInsertCommand
    {
        private RealEstateContext _dbContext;

        public PropertyConfigurationItemsInsertCommand(RealEstateContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Add(PropertyConfigurationItemsEdit propertyConfigurationItemsEdit)
        {
            var propertyConfigurationItems = new PropertyConfigurationItems();
            var propertyConfigurationItemsRep = new PropertyConfigurationItemsRepository(_dbContext);
            var propertyConfigurationItemsExisting = propertyConfigurationItemsRep
                .GetWhere(d => d.ID == propertyConfigurationItemsEdit.ID)
                .ToList();
            
            propertyConfigurationItems.ID = propertyConfigurationItemsEdit.ID;
            propertyConfigurationItems.PropertyConfigurationID = propertyConfigurationItemsEdit.PropertyConfigurationID;
            propertyConfigurationItems.ConfigurationItemID = propertyConfigurationItemsEdit.ConfigurationItemID;
            propertyConfigurationItems.ConfigurationOptionID = propertyConfigurationItemsEdit.ConfigurationOptionID;
            if(propertyConfigurationItemsExisting == null || propertyConfigurationItemsExisting.Count <= 0)
            {
                propertyConfigurationItemsRep.Insert(propertyConfigurationItems);
                _dbContext.SaveChanges();
            }
            

            return propertyConfigurationItems.ID;
            
        }
    }
}
