using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateBussinesLogic.Interfaces.DeveloperLogic;
using RealEstateBussinesLogic.Models.Developer;
using RealEstateDAL.Entities;

namespace RealEstate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private IDeveloperGetCommand _developerGetCommand;
        private IDeveloperInsertCommand _developerInsertCommand;
        private IDeveloperUpdateCommand _developerUpdateCommand;
        private IDeveloperDeleteCommand _developerDeleteCommand;

        public DeveloperController(IDeveloperGetCommand developerGetCommand,
            IDeveloperInsertCommand developerInsertCommand,
            IDeveloperUpdateCommand developerUpdateCommand,
            IDeveloperDeleteCommand developerDeleteCommand)
        {
            _developerGetCommand = developerGetCommand;
            _developerInsertCommand = developerInsertCommand;
            _developerUpdateCommand = developerUpdateCommand;
            _developerDeleteCommand = developerDeleteCommand;
        }

        [HttpGet]
        public IActionResult GetDeveloperList()
        {
            try
            {
                var developerList = _developerGetCommand.GetAllDevelopers();
                
                return Ok(developerList);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("InsertDeveloper")]
        public IActionResult AddDeveloper([FromBody] DeveloperEdit developerData)
        {
           try
            {   
                  var developerID = _developerInsertCommand.Add(developerData);
                  return Ok(developerID);
                    
               
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("UpdateDeveloper")]
        public IActionResult UpdateDeveloper([FromBody]DeveloperEdit developerData)
        {
          try
            {
                var developerID = _developerUpdateCommand.Edit(developerData);
                return Ok(developerID);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("DeleteDeveloper/{developerID}")]
        public IActionResult DeleteDeveloper([FromRoute] int developerID)
        {
            try
            {
                var resultID = _developerDeleteCommand.Delete(developerID);
                return Ok(resultID); ;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
