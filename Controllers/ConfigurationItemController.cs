using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateBussinesLogic.Interfaces.ConfigurationItem;
using RealEstateBussinesLogic.Models.ConfigurationItem;

namespace RealEstate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationItemController : ControllerBase
    {
        private IConfigurationItemGetCommand _configurationItemGetCommand;
        private IConfigurationItemInsertCommand _configurationItemInsertCommand;

        public ConfigurationItemController(IConfigurationItemGetCommand configurationItemGetCommand,
            IConfigurationItemInsertCommand configurationItemInsertCommand)
        {
            _configurationItemGetCommand = configurationItemGetCommand;
            _configurationItemInsertCommand = configurationItemInsertCommand;
        }
        [HttpGet]
        public IActionResult GetConfigurationItemList()
        {
            try
            {
                var configurationItemList = _configurationItemGetCommand.GetAllConfigurationItem();
                return Ok(configurationItemList);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult AddConfigurationItem([FromBody] ConfigurationItemEdit configurationItemData)
        {
            try
            {
                var configurationItemID = _configurationItemInsertCommand.Add(configurationItemData);
                return Ok(configurationItemID);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
