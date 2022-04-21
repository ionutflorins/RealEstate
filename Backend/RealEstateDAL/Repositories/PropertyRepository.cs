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
    public class PropertyRepository : GenericRepository<Property>
    {
        public PropertyRepository(RealEstateContext context) : base(context)
        {
        }

        public Property GetProperty(int propertyID)
        {
            return context.Properties.Find(propertyID);
        }

        public void Insert(Property property)
        {
            dbSet.Add(property);
        }

        public void Delete(int propertyID)
        {
            Property property = context.Properties.Find(propertyID);
            context.Properties.Remove(property);
        }
        public void Update(Property property)
        {
            if (property != null)
            {
                context.Entry(property).State = EntityState.Modified;
            }
        }
    }
}
