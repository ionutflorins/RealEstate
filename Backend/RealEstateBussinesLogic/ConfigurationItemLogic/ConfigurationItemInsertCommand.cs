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
    public class ConfigurationItemInsertCommand : IConfigurationItemInsertCommand
    {
        private RealEstateContext _dbContext;

        public ConfigurationItemInsertCommand(RealEstateContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Add(ConfigurationItemEdit configurationItemEdit)
        {
            var configurationItem = new ConfigurationItem();
            var configurationItemRep = new ConfigurationItemRepository(_dbContext);
            var configurationItemExisting = configurationItemRep
                .GetWhere(d => d.Description == configurationItemEdit.Description)
                .ToList();
            configurationItem.ID = configurationItemEdit.ID;
            configurationItem.Description = configurationItemEdit.Description;
            if(configurationItemExisting == null || configurationItemExisting.Count <= 0)
            {
                configurationItemRep.Insert(configurationItem);
                _dbContext.SaveChanges();
            }
            return configurationItem.ID;
        }
    }
}
