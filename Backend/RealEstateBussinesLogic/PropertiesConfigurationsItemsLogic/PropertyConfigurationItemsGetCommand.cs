using RealEstateBussinesLogic.Interfaces.PropertyConfigurationItemsLogic;
using RealEstateBussinesLogic.Models.PropertyConfigurationItems;
using RealEstateDAL.Context;
using RealEstateDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateBussinesLogic.PropertiesConfigurationsItemsLogic
{
    public class PropertyConfigurationItemsGetCommand : IPropertyConfigurationItemsGetCommand
    {
        private RealEstateContext _dbContext;

        public PropertyConfigurationItemsGetCommand(RealEstateContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<PropertyConfigurationItemsListView> GetAllPropertyConfigurationItems()
        {
            var propertyConfigItemRep = new PropertyConfigurationItemsRepository(_dbContext);
            var propertyConfigItemlist = propertyConfigItemRep.GetAll();
            var propertyConfigitemModelList = propertyConfigItemlist
                .Select(x => new PropertyConfigurationItemsListView { ID = x.ID, ConfigurationItemID = x.ConfigurationItemID, ConfigurationOptionID = x.ConfigurationOptionID, PropertyConfigurationID = x.PropertyConfigurationID })
                .ToList();
            return propertyConfigitemModelList;
        }

        public IList<PropertyConfigurationItemsListView> GetPropConfigItmByPropConfig(int propConfigId)
        {
            var propertyConfigItemRep = new PropertyConfigurationItemsRepository(_dbContext);
            var propertyConfigItemlist = propertyConfigItemRep.GetAll();
            var propertyConfigitemModelList = propertyConfigItemlist
                .Select(x => new PropertyConfigurationItemsListView { ID = x.ID, ConfigurationItemID = x.ConfigurationItemID, ConfigurationOptionID = x.ConfigurationOptionID, PropertyConfigurationID = x.PropertyConfigurationID })
                .Where(x => x.PropertyConfigurationID == propConfigId)
                .ToList();
            return propertyConfigitemModelList;
        }

    }
}
