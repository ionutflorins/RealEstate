using RealEstateBussinesLogic.Interfaces.ConfigurationOptionLogic;
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
    public class ConfigurationOptionDeleteCommand : IConfigurationOptionDeleteCommand
    {
        private RealEstateContext _dbContext;

        public ConfigurationOptionDeleteCommand(RealEstateContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Delete(int configurationOptionID)
        {
            ConfigurationOption configurationOptionExisting = null;
            using(var configurationOptionRep = new ConfigurationOptionRepository(_dbContext))
            {
                configurationOptionExisting = configurationOptionRep
                    .GetWhere(d => d.ID == configurationOptionID)
                    .FirstOrDefault();
                if(configurationOptionExisting == null)
                {
                    return 0;
                }

                configurationOptionRep.Delete(configurationOptionExisting);
                _dbContext.SaveChanges();
            }
            return configurationOptionExisting.ID;
        }
    }
}
