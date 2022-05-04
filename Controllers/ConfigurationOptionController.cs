using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateBussinesLogic.Interfaces.ConfigurationOptionLogic;
using RealEstateBussinesLogic.Models.ConfigurationOption;

namespace RealEstate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationOptionController : ControllerBase
    {
        private IConfigurationOptionGetCommand _configurationOptionGetCommand;
        private IConfigurationOptionInsertCommand _configurationOptionInsertCommand;
        private IConfigurationOptionUpdateCommand _configurationOptionUpdateCommand;
        private IConfigurationOptionDeleteCommand _configurationOptionDeleteCommand;

        public ConfigurationOptionController(IConfigurationOptionGetCommand configurationOptionGetCommand,
            IConfigurationOptionInsertCommand configurationOptionInsertCommand,
            IConfigurationOptionUpdateCommand configurationOptionUpdateCommand, 
            IConfigurationOptionDeleteCommand configurationOptionDeleteCommand)
        {
            _configurationOptionGetCommand = configurationOptionGetCommand;
            _configurationOptionInsertCommand = configurationOptionInsertCommand;
            _configurationOptionUpdateCommand = configurationOptionUpdateCommand;
            _configurationOptionDeleteCommand = configurationOptionDeleteCommand;

        }
        [HttpGet]
        public IActionResult GetConfigurationOptionList()
        {
            try
            {
                var configuratiOptionList = _configurationOptionGetCommand.GetAllConfigurationOption();
                return Ok(configuratiOptionList);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("InsertConfigurationOption")]
        public IActionResult AddConfigurationOption([FromBody] ConfigurationOptionEdit configurationOptionData)
        {
            try
            {
                var configurationOptionID = _configurationOptionInsertCommand.Add(configurationOptionData);
                return Ok(configurationOptionID);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("UpdateConfigurationOption")]
        public IActionResult Update([FromBody] ConfigurationOptionEdit configurationOptionData)
        {
            try
            {
                var configurationItemID = _configurationOptionUpdateCommand.Update(configurationOptionData);
                return Ok(configurationItemID);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("DeleteConfigurationOption/{configurationOptionID}")]
        public IActionResult DeleteConfigurationOption([FromRoute] int configurationOptionID)
        {
            try
            {
                var resultID = _configurationOptionDeleteCommand.Delete(configurationOptionID);
                return Ok(resultID);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
