using RealEstateBussinesLogic.Interfaces.PropertyConfigurationLogic;
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
    public class PropertyConfigurationDeleteCommand : IPropertyConfigurationDeleteCommand
    {
        private RealEstateContext _dbContext;

        public PropertyConfigurationDeleteCommand(RealEstateContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Delete(int propertyConfigID)
        {
            PropertyConfiguration propertyConfigurationExisting = null;

            using (var propertyConfigurationRep = new PropertyConfigurationRepository(_dbContext))
            {
                propertyConfigurationExisting = propertyConfigurationRep
                   .GetWhere(x => x.ID == propertyConfigID)
                   .FirstOrDefault();
                if (propertyConfigurationExisting == null)
                {
                    return 0;
                }

                propertyConfigurationRep.Delete(propertyConfigurationExisting);
                _dbContext.SaveChanges();
            }
            return propertyConfigurationExisting.ID;
        }
    }
}
