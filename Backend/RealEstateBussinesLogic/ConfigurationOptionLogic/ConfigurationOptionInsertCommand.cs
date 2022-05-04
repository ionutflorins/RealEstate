using RealEstateBussinesLogic.Interfaces.ConfigurationOptionLogic;
using RealEstateBussinesLogic.Models.ConfigurationItem;
using RealEstateBussinesLogic.Models.ConfigurationOption;
using RealEstateDAL.Context;
using RealEstateDAL.Entities;
using RealEstateDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateBussinesLogic.ConfigurationOptionLogic
{
    public class ConfigurationOptionInsertCommand : IConfigurationOptionInsertCommand
    {
        private RealEstateContext _dbContext;

        public ConfigurationOptionInsertCommand(RealEstateContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Add(ConfigurationOptionEdit configurationOptionEdit)
        {
            var configurationOption = new ConfigurationOption();
            var configurationOptionRep = new ConfigurationOptionRepository(_dbContext);
            var configurationOptionExisting = configurationOptionRep
                .GetWhere( d => d.Description == configurationOptionEdit.Description)
                .ToList();
            
            configurationOption.Description = configurationOptionEdit.Description;
            configurationOption.ConfigurationItemId = configurationOptionEdit.ConfigurationItemId;
            if(configurationOptionExisting == null || configurationOptionExisting.Count <= 0)
            {
                configurationOptionRep.Insert(configurationOption);
                _dbContext.SaveChanges();
            }
            return configurationOption.ID;
            
        }


    }
}
