using RealEstateBussinesLogic.Interfaces.ConfigurationOptionLogic;
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
    public class ConfigurationOptionUpdateCommand : IConfigurationOptionUpdateCommand
    {
        private RealEstateContext _dbContext;

        public ConfigurationOptionUpdateCommand(RealEstateContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Update(ConfigurationOptionEdit configurationOptionEdit)
        {

            ConfigurationOption configurationOptionExisting = null;
            using (var configurationOptionRep = new ConfigurationOptionRepository(_dbContext))
            {
                configurationOptionExisting = configurationOptionRep
                    .GetWhere(d => d.ID == configurationOptionEdit.ID)
                    .FirstOrDefault();
                if(configurationOptionExisting == null)
                {
                    return 0;
                }

                configurationOptionExisting.Description = configurationOptionEdit.Description;
                configurationOptionExisting.ConfigurationItemId = configurationOptionEdit.ConfigurationItemId;

                configurationOptionRep.Update(configurationOptionExisting);
                _dbContext.SaveChanges();
            }
            return configurationOptionExisting.ID;
        }
    }
}
