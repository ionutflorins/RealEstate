using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateBussinesLogic.Interfaces.ClientLogic;
using RealEstateBussinesLogic.Models.Client;

namespace RealEstate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private IClientGetCommand _clientGetCommand;
        private IClientInsertCommand _clientInsertCommand;
        private IClientUpdateCommand _clientUpdateCommand;
        private IClientDeleteCommand _clientDeleteCommand;
        public ClientController(IClientGetCommand clientGetCommand,
            IClientInsertCommand clientInsertCommand,
            IClientUpdateCommand clientUpdateCommand, 
            IClientDeleteCommand clientDeleteCommand)
        {
            _clientGetCommand = clientGetCommand;
            _clientInsertCommand = clientInsertCommand;
            _clientUpdateCommand = clientUpdateCommand;
            _clientDeleteCommand = clientDeleteCommand;

        }

        [HttpGet]
        public IActionResult GetClientsList()
        {
            try
            {
                var clientList = _clientGetCommand.GetAllClients();

                return Ok(clientList);

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("InsertClient")]
        public IActionResult AddClient([FromBody] ClientEdit clientData)
        {
            try
            {
                var clientID = _clientInsertCommand.Add(clientData);
                return Ok(clientID);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("UpdateClient")]
        public IActionResult UpdateClient([FromBody] ClientEdit clientData)
        {
            try
            {
                var clientID = _clientUpdateCommand.Edit(clientData);
                return Ok(clientID);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("DeleteClient/{clientID}")]
        public IActionResult DeleteClient([FromRoute] int clientID)
        {
            try
            {
                var resultID = _clientDeleteCommand.Delete(clientID);
                return Ok(resultID);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
