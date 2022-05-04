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
        private IConfigurationItemUpdateCommand _configurationItemUpdateCommand;
        private IConfigurationItemDeleteCommand _configurationItemDeleteCommand;

        public ConfigurationItemController(IConfigurationItemGetCommand configurationItemGetCommand,
            IConfigurationItemInsertCommand configurationItemInsertCommand,
            IConfigurationItemUpdateCommand configurationItemUpdateCommand,
            IConfigurationItemDeleteCommand configurationItemDeleteCommand)
        {
            _configurationItemGetCommand = configurationItemGetCommand;
            _configurationItemInsertCommand = configurationItemInsertCommand;
            _configurationItemUpdateCommand = configurationItemUpdateCommand;
            _configurationItemDeleteCommand = configurationItemDeleteCommand;

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
        [HttpPost("InsertConfigurationItem")]
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
        [HttpPost("UpdateConfigurationItem")]
        public IActionResult Update([FromBody] ConfigurationItemEdit configurationItemData)
        {
            try
            {
                var configurationItemID = _configurationItemUpdateCommand.Update(configurationItemData);
                return Ok(configurationItemID);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("DeleteConfigurationItem/{configurationItemID}")]
        public IActionResult DeleteConfigurationItem([FromRoute] int configurationItemID)
        {
            try
            {
                var resultID = _configurationItemDeleteCommand.Delete(configurationItemID);
                return Ok(resultID);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
