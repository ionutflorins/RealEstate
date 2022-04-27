using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateBussinesLogic.Interfaces.PropertyConfigurationItemsLogic;

namespace RealEstate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyConfigurationItemsController : ControllerBase
    {
        private IPropertyConfigurationItemsGetCommand _propertyConfigurationItemsGetCommand;

        public PropertyConfigurationItemsController(IPropertyConfigurationItemsGetCommand propertyConfigurationItemGetCommand)
        {
            _propertyConfigurationItemsGetCommand = propertyConfigurationItemGetCommand;
        }

        [HttpGet]
        public IActionResult GetAllPropertyConfigurationItemsList()
        {
            try
            {
                var propertyConfigItemsList = _propertyConfigurationItemsGetCommand.GetAllPropertyConfigurationItems();
                return Ok(propertyConfigItemsList);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
