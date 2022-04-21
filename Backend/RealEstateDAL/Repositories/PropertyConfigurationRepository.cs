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
    public class PropertyConfigurationRepository : GenericRepository<PropertyConfiguration>
    {
        public PropertyConfigurationRepository(RealEstateContext context) : base(context)
        {
        }

        public PropertyConfiguration GetPropertyConfiguration(int propertyConfigurationID)
        {
            return context.PropertiesConfigurations.Find(propertyConfigurationID);
        }

        public void Insert(PropertyConfiguration propertyConfiguration)
        {
            dbSet.Add(propertyConfiguration);
        }

        public void Delete(int propertyConfigurationID)
        {
            PropertyConfiguration propertyConfiguration = context.PropertiesConfigurations.Find(propertyConfigurationID);
            context.PropertiesConfigurations.Remove(propertyConfiguration);
        }
        public void Update(PropertyConfiguration propertyConfiguration)
        {
            if (propertyConfiguration != null)
            {
                context.Entry(propertyConfiguration).State = EntityState.Modified;
            }
        }
    }
}
