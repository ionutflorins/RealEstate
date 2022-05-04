using RealEstateBussinesLogic.Interfaces.ConfigurationItem;
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
    public class ConfigurationItemDeleteCommand : IConfigurationItemDeleteCommand
    {
        private RealEstateContext _dbContext;

        public ConfigurationItemDeleteCommand(RealEstateContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Delete(int configurationItemID)
        {
            ConfigurationItem configurationItemExisting = null;
            using(var configurationItemRep = new ConfigurationItemRepository(_dbContext))
            {
                configurationItemExisting = configurationItemRep
                    .GetWhere(d => d.ID == configurationItemID)
                    .FirstOrDefault();
                if(configurationItemExisting == null)
                {
                    return 0;
                }
                configurationItemRep.Delete(configurationItemID);
                _dbContext.SaveChanges();
            }
            return configurationItemExisting.ID;
        }
    }
}
