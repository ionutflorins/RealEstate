using RealEstateBussinesLogic.Interfaces.ContractLogic;
using RealEstateBussinesLogic.Models.Contract;
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
    public class ContractUpdateCommand : IContractUpdateCommand
    {
        private RealEstateContext _dbContext;

        public ContractUpdateCommand(RealEstateContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Update(ContractEdit contractEdit)
        {
            Contract contractExisting = null;
            using (var contractRep = new ContractRepository(_dbContext))
            {
                contractExisting = contractRep
                    .GetWhere(d => d.ID == contractEdit.ID)
                    .FirstOrDefault();

                if (contractExisting == null)
                {
                    return 0;
                }

                contractExisting.ContractNumber = contractEdit.ContractNumber;
                contractExisting.Date = contractEdit.Date;
                contractExisting.ClientID = contractEdit.ClientID;
                contractExisting.DeveloperID = contractEdit.DeveloperID;
                contractExisting.PropertyID = contractEdit.PropertyID;

                contractRep.Update(contractExisting);
                _dbContext.SaveChanges();
            }
            return contractExisting.ID;

        }
    }
}
