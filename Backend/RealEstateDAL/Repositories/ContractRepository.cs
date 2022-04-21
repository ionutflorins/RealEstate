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
    public class ContractRepository : GenericRepository<Contract>
    {
        public ContractRepository(RealEstateContext context) : base(context)
        {
        }

        public Contract GetContract(int contractID)
        {
            return context.Contracts.Find(contractID);
        }

        public void Insert(Contract contract)
        {
            dbSet.Add(contract);
        }

        public void Delete(int contractID)
        {
            Contract contract = context.Contracts.Find(contractID);
            context.Contracts.Remove(contract);
        }
        public void Update(Contract contract)
        {
            if (contract != null)
            {
                context.Entry(contract).State = EntityState.Modified;
            }
        }

    }
}
