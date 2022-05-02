using RealEstateBussinesLogic.Interfaces.PropertyConfigurationLogic;
using RealEstateBussinesLogic.Models.PropertyConfiguration;
using RealEstateDAL.Context;
using RealEstateDAL.Entities;
using RealEstateDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateBussinesLogic.PropertiesConfigurations
{
    public class PropertyConfigurationInsertCommand : IPropertyConfigurationInsertCommand
    {
        private RealEstateContext _dbContext;

        public PropertyConfigurationInsertCommand(RealEstateContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Add(PropertyConfigurationEdit propertyConfigurationEdit)
        {
            var propertyConfiguration = new PropertyConfiguration();
            var propertyConfigurationRep = new PropertyConfigurationRepository(_dbContext);
            var propertyConfigurationExisting = propertyConfigurationRep
                .GetWhere(d => d.FormNumber == propertyConfigurationEdit.FormNumber)
                .ToList();
            propertyConfiguration.ID = propertyConfigurationEdit.ID;
            propertyConfiguration.FormNumber = propertyConfigurationEdit.FormNumber;
            propertyConfiguration.ContractID = propertyConfigurationEdit.ContractID;
            if(propertyConfigurationExisting == null || propertyConfigurationExisting.Count <= 0)
            {
                propertyConfigurationRep.Insert(propertyConfiguration);
                _dbContext.SaveChanges();
            }
            return propertyConfiguration.ID;
        }
    }
}
