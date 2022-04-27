using RealEstateBussinesLogic.Interfaces.PropertyConfigurationLogic;
using RealEstateBussinesLogic.Models.PropertyConfiguration;
using RealEstateDAL.Context;
using RealEstateDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateBussinesLogic.PropertiesConfigurations
{
    public class PropertyConfigurationGetCommand : IPropertyConfigurationGetCommand
    {
        private RealEstateContext _dbContext;

        public PropertyConfigurationGetCommand(RealEstateContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<PropertyConfigurationListView> GetAllPropertyConfiguration()
        {
            var propertyConfigurationRep = new PropertyConfigurationRepository(_dbContext);
            var propertyConfigurationList = propertyConfigurationRep.GetAll();
            var propertyConfigurationListModel = propertyConfigurationList
                .Select(x => new PropertyConfigurationListView { ID = x.ID, FormNumber = x.FormNumber, ContractID = x.ContractID })
                .ToList();
            return propertyConfigurationListModel;
        }
    }
}
