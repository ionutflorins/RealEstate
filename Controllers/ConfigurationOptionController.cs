using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateBussinesLogic.Interfaces.ConfigurationOptionLogic;

namespace RealEstate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationOptionController : ControllerBase
    {
        private IConfigurationOptionGetCommand _configurationOptionGetCommand;

        public ConfigurationOptionController(IConfigurationOptionGetCommand configurationOptionGetCommand)
        {
            _configurationOptionGetCommand = configurationOptionGetCommand;
        }
        [HttpGet]
        public IActionResult GetConfigurationOptionList()
        {
            try
            {
                var configurationoptionList = _configurationOptionGetCommand.GetAllConfigurationOption();
                return Ok(configurationoptionList);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
