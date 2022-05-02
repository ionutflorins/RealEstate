using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateBussinesLogic.Interfaces.ProjectLogic;
using RealEstateBussinesLogic.Models.Project;

namespace RealEstate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private IProjectGetCommand _projectGetCommand;
        private IProjectInsertCommand _projectInsertCommand;

        public ProjectController(IProjectGetCommand projectGetCommand,
            IProjectInsertCommand projectInsertCommand)
        {
            _projectGetCommand = projectGetCommand;
            _projectInsertCommand = projectInsertCommand;
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
        [HttpPost]
        public IActionResult AddProject([FromBody] ProjectEdit projectData)
        {
            try
            {
                var projectId = _projectInsertCommand.Add(projectData);
                return Ok(projectId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

