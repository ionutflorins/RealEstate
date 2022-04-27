using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateBussinesLogic.Interfaces.ContractLogic;

namespace RealEstate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private IContractGetCommand _contractGetCommand;

        public ContractController(IContractGetCommand contractGetCommand)
        {
            _contractGetCommand = contractGetCommand;
        }
        [HttpGet]
        public IActionResult GetAllContractList()
        {
            try
            {
                var contractList = _contractGetCommand.GetAllContract();
                return Ok(contractList);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
