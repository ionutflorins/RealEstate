using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateBussinesLogic.Interfaces.PropertyConfigurationLogic;

namespace RealEstate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyConfigurationController : ControllerBase
    {
        private IPropertyConfigurationGetCommand _propertyConfigurationGetCommand;

        public PropertyConfigurationController(IPropertyConfigurationGetCommand propertyConfigurationGetCommand)
        {
            _propertyConfigurationGetCommand = propertyConfigurationGetCommand;
        }
        [HttpGet]
        public IActionResult GetPropertyConfigurationList()
        {
            try
            {
                var propertyConfigurationList = _propertyConfigurationGetCommand.GetAllPropertyConfiguration();
                return Ok(propertyConfigurationList);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
