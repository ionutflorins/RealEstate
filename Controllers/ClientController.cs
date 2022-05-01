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
        public ClientController(IClientGetCommand clientGetCommand,
            IClientInsertCommand clientInsertCommand)
        {
            _clientGetCommand = clientGetCommand;
            _clientInsertCommand = clientInsertCommand;
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
        [HttpPost]
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
    }
}
