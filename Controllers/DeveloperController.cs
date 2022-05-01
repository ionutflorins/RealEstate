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

        public DeveloperController(IDeveloperGetCommand developerGetCommand,
            IDeveloperInsertCommand developerInsertCommand)
        {
            _developerGetCommand = developerGetCommand;
            _developerInsertCommand = developerInsertCommand;
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

        [HttpPost]
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
       

        






    }
}
