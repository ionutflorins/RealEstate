using RealEstateBussinesLogic.Interfaces.ContractLogic;
using RealEstateBussinesLogic.Models.Contract;
using RealEstateDAL.Context;
using RealEstateDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateBussinesLogic.ContractLogic
{
    public class ContractGetCommand : IContractGetCommand
    {
        private RealEstateContext _dbContext;

        public ContractGetCommand(RealEstateContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IList<ContractListView> GetAllContract()
        {
            var contractRep = new ContractRepository(_dbContext);
            var contractList = contractRep.GetAll();
            var contractListModel = contractList
                .Select(x => new ContractListView { ID = x.ID, ContractNumber = x.ContractNumber, Date = x.Date})
                .ToList();
            return contractListModel;
        }
    }
}
