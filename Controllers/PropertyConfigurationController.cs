using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateBussinesLogic.Interfaces.PropertyConfigurationLogic;
using RealEstateBussinesLogic.Models.PropertyConfiguration;

namespace RealEstate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyConfigurationController : ControllerBase
    {
        private IPropertyConfigurationGetCommand _propertyConfigurationGetCommand;
        private IPropertyConfigurationInsertCommand _propertyConfigurationInsertCommand;

        public PropertyConfigurationController(IPropertyConfigurationGetCommand propertyConfigurationGetCommand,
            IPropertyConfigurationInsertCommand propertyConfigurationInsertCommand)
        {
            _propertyConfigurationGetCommand = propertyConfigurationGetCommand;
            _propertyConfigurationInsertCommand = propertyConfigurationInsertCommand;
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
        [HttpPost]
        public IActionResult AddPropertyConfiguration([FromBody] PropertyConfigurationEdit propertyConfigurationData)
        {
            try
            {
                var propertyConfigurationID = _propertyConfigurationInsertCommand.Add(propertyConfigurationData);
                return Ok(propertyConfigurationID);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
