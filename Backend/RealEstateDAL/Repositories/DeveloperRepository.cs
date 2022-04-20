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
    public class DeveloperRepository : BaseRepository<Developer>
    {
        public DeveloperRepository(RealEstateContext context) 
            : base(context)
        {

        }


        public RealEstateContext RealEstateContext
        {
            get { return context as RealEstateContext; }
        }

    }
}
