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
    public class ContractInsertCommand : IContractInsertCommand
    {
        private RealEstateContext _dbContext;

        public ContractInsertCommand(RealEstateContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Add(ContractEdit contractEdit)
        {
            var contract = new Contract();
            var contractRep = new ContractRepository(_dbContext);
            var contractExisting = contractRep
                .GetWhere(d => d.ContractNumber == contractEdit.ContractNumber)
                .ToList();
            contract.ID = contractEdit.ID;
            contract.ContractNumber= contractEdit.ContractNumber;
            contract.Date = contractEdit.Date;
            contract.ClientID = contractEdit.ClientID;
            contract.DeveloperID = contractEdit.DeveloperID;
            contract.PropertyID = contractEdit.PropertyID;

            if(contractExisting == null || contractExisting.Count <= 0)
            {
                contractRep.Insert(contract);
                _dbContext.SaveChanges();
            }
            return contract.ID;

        }
    }
}
