using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateBussinesLogic.Interfaces.PropertyLogic;

namespace RealEstate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private IPropertyGetCommand _propertyGetCommand;

        public PropertyController(IPropertyGetCommand propertyGetCommand)
        {
            _propertyGetCommand = propertyGetCommand;
        }
        [HttpGet]
        public IActionResult GetPropertyList()
        {
            try
            {
                var propertyList = _propertyGetCommand.GetAllProperty();
                return Ok(propertyList);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
