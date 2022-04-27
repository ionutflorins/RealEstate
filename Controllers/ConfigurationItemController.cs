using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateBussinesLogic.Interfaces.ConfigurationItem;

namespace RealEstate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationItemController : ControllerBase
    {
        private IConfigurationItemGetCommand _configuratioItemGetCommand;

        public ConfigurationItemController(IConfigurationItemGetCommand configuratioItemGetCommand)
        {
            _configuratioItemGetCommand = configuratioItemGetCommand;
        }
        [HttpGet]
        public IActionResult GetConfigurationItemList()
        {
            try
            {
                var configurationItemList = _configuratioItemGetCommand.GetAllConfigurationItem();
                return Ok(configurationItemList);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
