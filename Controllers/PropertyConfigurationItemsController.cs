using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateBussinesLogic.Interfaces.PropertyConfigurationItemsLogic;
using RealEstateBussinesLogic.Models.PropertyConfigurationItems;

namespace RealEstate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyConfigurationItemsController : ControllerBase
    {
        private IPropertyConfigurationItemsGetCommand _propertyConfigurationItemsGetCommand;
        private IPropertyConfigurationItemsInsertCommand _propertyConfigurationItemsInsertCommand;

        public PropertyConfigurationItemsController(IPropertyConfigurationItemsGetCommand propertyConfigurationItemGetCommand,
            IPropertyConfigurationItemsInsertCommand propertyConfigurationItemsInsertCommand)
        {
            _propertyConfigurationItemsGetCommand = propertyConfigurationItemGetCommand;
            _propertyConfigurationItemsInsertCommand = propertyConfigurationItemsInsertCommand;
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
        [HttpPost]
        public IActionResult InsertPropertyConfigurationItems([FromBody] PropertyConfigurationItemsEdit propertyConfigurationItemsData)
        {
            try
            {
                var propertyConfigItemsId = _propertyConfigurationItemsInsertCommand.Add(propertyConfigurationItemsData);
                return Ok(propertyConfigItemsId);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
