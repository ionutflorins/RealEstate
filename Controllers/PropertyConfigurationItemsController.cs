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
        private IPropertyConfigurationItemsUpdateCommand _propertyConfigurationItemsUpdateCommand;
        private IPropertyConfigurationItemsDeleteCommand _propertyConfigurationItemsDeleteCommand;

        public PropertyConfigurationItemsController(IPropertyConfigurationItemsGetCommand propertyConfigurationItemGetCommand,
            IPropertyConfigurationItemsInsertCommand propertyConfigurationItemsInsertCommand, 
            IPropertyConfigurationItemsUpdateCommand propertyConfigurationItemsUpdateCommand,
            IPropertyConfigurationItemsDeleteCommand propertyConfigurationItemsDeleteCommand)
        {
            _propertyConfigurationItemsGetCommand = propertyConfigurationItemGetCommand;
            _propertyConfigurationItemsInsertCommand = propertyConfigurationItemsInsertCommand;
            _propertyConfigurationItemsUpdateCommand = propertyConfigurationItemsUpdateCommand;
            _propertyConfigurationItemsDeleteCommand = propertyConfigurationItemsDeleteCommand;

        }
        [HttpGet("GetPropConfigItmByPropConfig/{propConfigId}")]
        public IActionResult GetPropConfigItmByPropConfig([FromRoute]int propConfigId)
        {
            try
            {
                var propertyConfigItemsList = _propertyConfigurationItemsGetCommand.GetPropConfigItmByPropConfig(propConfigId);
                return Ok(propertyConfigItemsList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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

        [HttpPost("InsertPropertyConfigurationItems")]
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

        [HttpPost("UpdatePropertyConfigurationItems")]
        public IActionResult UpdateDeveloper([FromBody] PropertyConfigurationItemsEdit propertyConfigurationItemsData)
        {
            try
            {
                var propertyConfigItemsId = _propertyConfigurationItemsUpdateCommand.Update(propertyConfigurationItemsData);
                return Ok(propertyConfigItemsId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("DeletePropertyConfigurationItems/{propertyConfigItemsId}")]
        public IActionResult DeletePropertyConfigurationItems([FromRoute] int propertyConfigItemsId)
        {
            try
            {
                var resultID = _propertyConfigurationItemsDeleteCommand.Delete(propertyConfigItemsId);
                return Ok(resultID); ;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
