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
    public class ConfigurationItemRepository : GenericRepository<ConfigurationItem>
    {
        public ConfigurationItemRepository(RealEstateContext context)
            : base(context)
        {

        }
        public ConfigurationItem GetConfigurationItem(int configurationItemID)
        {
            return context.ConfigurationsItems.Find(configurationItemID);
        }

        public void Insert(ConfigurationItem configurationItem)
        {
            dbSet.Add(configurationItem);
        }

        public void Delete(int configurationItemID )
        {
            ConfigurationItem configurationItem = context.ConfigurationsItems.Find(configurationItemID);
            context.ConfigurationsItems.Remove(configurationItem);
        }
        public void Update(ConfigurationItem configurationItem)
        {
            if (configurationItem != null)
            {
                context.Entry(configurationItem).State = EntityState.Modified;
            }
        }

    }
}
