using Microsoft.EntityFrameworkCore;
using RealEstateDAL.Context;
using RealEstateDAL.Entities;
using RealEstateDAL.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDAL.Repositories
{
    public class ConfigurationOptionRepository : GenericRepository<ConfigurationOption>
    {
        public ConfigurationOptionRepository(RealEstateContext context) : base(context)
        {
        }

        

        public ConfigurationOption GetConfigurationOption(int configurationOptionID)
        {
            return context.ConfigurationsOptions.Find(configurationOptionID);
        }

        public void Insert(ConfigurationOption configurationOption)
        {
            dbSet.Add(configurationOption);
        }

        public void DeleteConfigurationOption(int configurationOptionID)
        {
            ConfigurationOption configurationOption = context.ConfigurationsOptions.Find(configurationOptionID);
            context.ConfigurationsOptions.Remove(configurationOption);
        }
        public void Update(ConfigurationOption configurationOption)
        {
            if (configurationOption != null)
            {
                context.Entry(configurationOption).State = EntityState.Modified;
            }
        }


    }
}
