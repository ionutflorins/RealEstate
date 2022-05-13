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
        private IPropertyUpdateCommand _propertyUpdateCommand;
        private IPropertyDeleteCommand _propertyDeleteCommand;

        public PropertyController(IPropertyGetCommand propertyGetCommand,
            IPropertyInsertCommand propertyInsertCommand, 
            IPropertyUpdateCommand propertyUpdateCommand,
            IPropertyDeleteCommand propertyDeleteCommand)
        {
            _propertyGetCommand = propertyGetCommand;
            _propertyInsertCommand = propertyInsertCommand;
            _propertyUpdateCommand = propertyUpdateCommand;
            _propertyDeleteCommand = propertyDeleteCommand;

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
        [HttpPost("InsertProperty")]
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

        [HttpPost("UpdateProperty")]
        public IActionResult UpdateDeveloper([FromBody] PropertyEdit propertyData)
        {
            try
            {
                var propertyID = _propertyUpdateCommand.Edit(propertyData);
                return Ok(propertyID);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("DeleteProperty/{propertyID}")]
        public IActionResult DeleteProperty([FromRoute] int propertyID)
        {
            try
            {
                var resultID = _propertyDeleteCommand.Delete(propertyID);
                return Ok(resultID); ;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
