using RealEstateBussinesLogic.Interfaces.ConfigurationOptionLogic;
using RealEstateBussinesLogic.Models.ConfigurationOption;
using RealEstateDAL.Context;
using RealEstateDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateBussinesLogic.ConfigurationOprionLogic
{
    public class ConfigurationOptionGetCommand : IConfigurationOptionGetCommand
    {
        private RealEstateContext _dbContext;

        public ConfigurationOptionGetCommand(RealEstateContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<ConfigurationOptionListView> GetAllConfigurationOption()
        {
            var configurationOptionRep = new ConfigurationOptionRepository(_dbContext);
            var configurationOptionList = configurationOptionRep.GetAll();
            var configurationOptionListModel = configurationOptionList
                .Select(x => new ConfigurationOptionListView { ID = x.ID, Description = x.Description, ConfigurationItemId = x.ConfigurationItemId})
                .ToList();
            return configurationOptionListModel;
        }

        public IList<ConfigurationOptionListView> GetConfigOptionAfterID(int configItemID)
        {
            var configurationOptionRep = new ConfigurationOptionRepository(_dbContext);
            var configurationOptionList = configurationOptionRep.GetAll();
            var configurationOptionListModel = configurationOptionList
                .Select(x => new ConfigurationOptionListView { ID = x.ID, Description = x.Description, ConfigurationItemId = x.ConfigurationItemId })
                .Where(x => x.ConfigurationItemId == configItemID)
                .ToList();
            return configurationOptionListModel;
        }

    }
}
