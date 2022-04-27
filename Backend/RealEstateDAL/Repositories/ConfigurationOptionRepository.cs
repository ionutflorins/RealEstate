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
    }
}
