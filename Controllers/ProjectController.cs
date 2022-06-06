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
        private IProjectUpdateCommand _projectUpdateCommand;
        private IProjectDeleteCommand _projectDeleteCommand;

        public ProjectController(IProjectGetCommand projectGetCommand,
            IProjectInsertCommand projectInsertCommand,
            IProjectUpdateCommand projectUpdateCommand,
            IProjectDeleteCommand projectDeleteCommand)
        {
            _projectGetCommand = projectGetCommand;
            _projectInsertCommand = projectInsertCommand;
            _projectUpdateCommand = projectUpdateCommand;
            _projectDeleteCommand = projectDeleteCommand;

        }

        [HttpGet("ProjectByDev/{devID}")]
        public IActionResult GetProjectListByDev([FromRoute] int devID)
        {
            try
            {
                var projectList = _projectGetCommand.GetProjectByDev(devID);
                return Ok(projectList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetProjectList()
        {
            try
            {
                var projectList = _projectGetCommand.GetAllProject();
                return Ok(projectList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("InsertProject")]
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

        [HttpPost("UpdateProject")]
        public IActionResult UpdateClient([FromBody] ProjectEdit projectData)
        {
            try
            {
                var projectId = _projectUpdateCommand.Update(projectData);
                return Ok(projectId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("DeleteProject/{projectId}")]
        public IActionResult DeleteDeveloper([FromRoute] int projectId)
        {
            try
            {
                var resultID = _projectDeleteCommand.Delete(projectId);
                return Ok(resultID); ;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

