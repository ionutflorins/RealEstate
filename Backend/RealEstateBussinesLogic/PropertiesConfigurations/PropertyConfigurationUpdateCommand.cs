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
    public class PropertyConfigurationUpdateCommand : IPropertyConfigurationUpdateCommand
    {
        private RealEstateContext _dbContext;

        public PropertyConfigurationUpdateCommand(RealEstateContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Update(PropertyConfigurationEdit propertyConfigurationEdit)
        {
            PropertyConfiguration propertyConfigurationExisting = null;
            using (var propertyConfigurationRep = new PropertyConfigurationRepository(_dbContext))
            {
                propertyConfigurationExisting = propertyConfigurationRep
                   .GetWhere(d => d.ID == propertyConfigurationEdit.ID)
                   .FirstOrDefault();

                if (propertyConfigurationExisting == null)
                {
                    return 0;
                }

                propertyConfigurationExisting.FormNumber = propertyConfigurationEdit.FormNumber;
                propertyConfigurationExisting.ContractID = propertyConfigurationEdit.ContractID;

                propertyConfigurationRep.Update(propertyConfigurationExisting);
                _dbContext.SaveChanges();
            }
            return propertyConfigurationExisting.ID;

        }

    }
}
