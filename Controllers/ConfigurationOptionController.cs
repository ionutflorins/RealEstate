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

        public ConfigurationOptionController(IConfigurationOptionGetCommand configurationOptionGetCommand,
            IConfigurationOptionInsertCommand configurationOptionInsertCommand)
        {
            _configurationOptionGetCommand = configurationOptionGetCommand;
            _configurationOptionInsertCommand = configurationOptionInsertCommand;
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
        [HttpPost]
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
    }
}
