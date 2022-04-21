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
    public class PropertyConfigurationItemsRepository : GenericRepository<PropertyConfigurationItems>
    {
        public PropertyConfigurationItemsRepository(RealEstateContext context) : base(context)
        {

        }
        public PropertyConfigurationItems GetPropertyConfigurationItems(int propertyConfigurationItemsID)
        {
            return context.PropertiesConfigurationsItems.Find(propertyConfigurationItemsID);
        }

        public void Insert(PropertyConfigurationItems propertyConfigurationItems)
        {
            dbSet.Add(propertyConfigurationItems);
        }

        public void Delete(int propertyConfigurationItemsID)
        {
            PropertyConfigurationItems propertyConfigurationItems = context.PropertiesConfigurationsItems.Find(propertyConfigurationItemsID);
            context.PropertiesConfigurationsItems.Remove(propertyConfigurationItems);
        }
        public void Update(PropertyConfigurationItems propertyConfigurationItems)
        {
            if (propertyConfigurationItems != null)
            {
                context.Entry(propertyConfigurationItems).State = EntityState.Modified;
            }
        }
    }
}
