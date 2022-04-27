using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateBussinesLogic.Interfaces.ProjectLogic;

namespace RealEstate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private IProjectGetCommand _projectGetCommand;

        public ProjectController(IProjectGetCommand projectGetCommand)
        {
            _projectGetCommand = projectGetCommand;
        }
        [HttpGet]
        public IActionResult GetProjectList()
        {
            try
            {
                var projectList = _projectGetCommand.GetAllProject();
                return Ok(projectList);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
