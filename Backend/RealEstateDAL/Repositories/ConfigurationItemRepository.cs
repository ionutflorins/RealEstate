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
    }
}
