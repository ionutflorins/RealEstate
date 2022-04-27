using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateBussinesLogic.Interfaces.DeveloperLogic;
using RealEstateDAL.Entities;

namespace RealEstate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private IDeveloperGetCommand _developerGetCommand;

        public DeveloperController(IDeveloperGetCommand developerGetCommand)
        {
            _developerGetCommand = developerGetCommand;
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

        






    }
}
