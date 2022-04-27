using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateBussinesLogic.Interfaces.ClientLogic;

namespace RealEstate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private IClientGetCommand _clientGetCommand;
        public ClientController(IClientGetCommand clientGetCommand)
        {
            _clientGetCommand = clientGetCommand;
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
    }
}
