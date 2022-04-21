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
    public class DeveloperRepository : GenericRepository<Developer>
    {
        public DeveloperRepository(RealEstateContext context) 
            : base(context)
        {

        }
        public Developer GetDeveloper(int developerID)
        {
            return context.Developers.Find(developerID);
        }

        public void Insert(Developer developer)
        {
            dbSet.Add(developer);
        }

        public void Delete(int developerID)
        {
            Developer developer = context.Developers.Find(developerID);
            context.Developers.Remove(developer);
        }
        public void Update(Developer developer)
        {
            if (developer != null)
            {
                context.Entry(developer).State = EntityState.Modified;
            }
        }
    }
}
