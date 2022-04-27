using RealEstateBussinesLogic.Interfaces.ConfigurationItem;
using RealEstateBussinesLogic.Models.ConfigurationItem;
using RealEstateDAL.Context;
using RealEstateDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateBussinesLogic.ConfigurationItemLogic
{
    public class ConfigurationItemGetCommand : IConfigurationItemGetCommand
    {
        private RealEstateContext _dbContext;

        public ConfigurationItemGetCommand(RealEstateContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<ConfigurationItemListView> GetAllConfigurationItem()
        {
            var configurationItemRep = new ConfigurationItemRepository(_dbContext);
            var configurationItemList = configurationItemRep.GetAll();
            var configurationItemListModel = configurationItemList
                .Select(x => new ConfigurationItemListView { ID = x.ID, Description = x.Description })
                .ToList();
            return configurationItemListModel;
        }
    }
}
