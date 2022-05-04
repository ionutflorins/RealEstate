using RealEstateBussinesLogic.Interfaces.ContractLogic;
using RealEstateDAL.Context;
using RealEstateDAL.Entities;
using RealEstateDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateBussinesLogic.ContractLogic
{
    public class ContractDeleteCommand : IContractDeleteCommand
    {
        private RealEstateContext _dbContext;

        public ContractDeleteCommand(RealEstateContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Delete(int contractID)
        {
            Contract contractExisting = null;
            using (var contractRep = new ContractRepository(_dbContext))
            {
                contractExisting = contractRep
                     .GetWhere(d => d.ID == contractID)
                     .FirstOrDefault();
                if (contractExisting == null)
                {
                    return 0;
                }

                contractRep.Delete(contractExisting);
                _dbContext.SaveChanges();
            }
            return contractExisting.ID;
        }
    }
}
