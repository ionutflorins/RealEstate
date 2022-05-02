using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateBussinesLogic.Interfaces.PropertyLogic;
using RealEstateBussinesLogic.Models.Property;

namespace RealEstate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private IPropertyGetCommand _propertyGetCommand;
        private IPropertyInsertCommand _propertyInsertCommand;

        public PropertyController(IPropertyGetCommand propertyGetCommand,
            IPropertyInsertCommand propertyInsertCommand)
        {
            _propertyGetCommand = propertyGetCommand;
            _propertyInsertCommand = propertyInsertCommand;
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
        [HttpPost]
        public IActionResult AddProperty([FromBody] PropertyEdit propertyData)
        {
            try
            {
                var propertyID = _propertyInsertCommand.Add(propertyData);
                return Ok(propertyID);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
