using RealEstateBussinesLogic.Interfaces.ConfigurationItem;
using RealEstateBussinesLogic.Models.ConfigurationItem;
using RealEstateDAL.Context;
using RealEstateDAL.Entities;
using RealEstateDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateBussinesLogic.ConfigurationItemLogic
{
    public class ConfigurationItemUpdateCommand : IConfigurationItemUpdateCommand
    {
        private RealEstateContext _dbContext;

        public ConfigurationItemUpdateCommand(RealEstateContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Update(ConfigurationItemEdit configurationItemEdit)
        {
            ConfigurationItem configurationItemExisting = null;
            using(var configurationItemRep = new ConfigurationItemRepository(_dbContext))
            {
                configurationItemExisting = configurationItemRep
                    .GetWhere(d => d.ID == configurationItemEdit.ID)
                    .FirstOrDefault();
                if(configurationItemExisting == null)
                {
                    return 0;
                }

                configurationItemExisting.Description = configurationItemEdit.Description;

                configurationItemRep.Update(configurationItemExisting);
                _dbContext.SaveChanges();

            }
            return configurationItemExisting.ID;
        }
    }
}
