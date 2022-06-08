﻿using Microsoft.AspNetCore.Http;
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
        private IPropertyConfigurationUpdateCommand _propertyConfigurationUpdateCommand;
        private IPropertyConfigurationDeleteCommand _propertyConfigurationDeleteCommand;

        public PropertyConfigurationController(IPropertyConfigurationGetCommand propertyConfigurationGetCommand,
            IPropertyConfigurationInsertCommand propertyConfigurationInsertCommand,
            IPropertyConfigurationUpdateCommand propertyConfigurationUpdateCommand,
            IPropertyConfigurationDeleteCommand propertyConfigurationDeleteCommand)
        {
            _propertyConfigurationGetCommand = propertyConfigurationGetCommand;
            _propertyConfigurationInsertCommand = propertyConfigurationInsertCommand;
            _propertyConfigurationUpdateCommand = propertyConfigurationUpdateCommand;
            _propertyConfigurationDeleteCommand = propertyConfigurationDeleteCommand;

        }

        [HttpGet("GetPropConfigByContrId/{contractId}")]
        public IActionResult GetPropertyConfigurationList([FromRoute] int contractId)
        {
            try
            {
                var propertyConfigurationList = _propertyConfigurationGetCommand.GetPropConfigByContract(contractId);
                return Ok(propertyConfigurationList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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

        [HttpPost("InsertPropertyConfiguration")]
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
        [HttpPost("UpdatePropertyConfiguration")]
        public IActionResult UpdatePropertyConfiguration([FromBody] PropertyConfigurationEdit propertyConfigurationData)
        {
            try
            {
                var propertyConfigurationID = _propertyConfigurationUpdateCommand.Update(propertyConfigurationData);
                return Ok(propertyConfigurationID);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("DeletePropertyConfiguration/{propertyConfigID}")]
        public IActionResult DeleteDeveloper([FromRoute] int propertyConfigID)
        {
            try
            {
                var resultID = _propertyConfigurationDeleteCommand.Delete(propertyConfigID);
                return Ok(resultID); ;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
