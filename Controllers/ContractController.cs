using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateBussinesLogic.Interfaces.ContractLogic;
using RealEstateBussinesLogic.Models.Contract;

namespace RealEstate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private IContractGetCommand _contractGetCommand;
        private IContractInsertCommand _contractInsertCommand;

        public ContractController(IContractGetCommand contractGetCommand,
            IContractInsertCommand contractInsertCommand)
        {
            _contractGetCommand = contractGetCommand;
            _contractInsertCommand = contractInsertCommand;
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
        [HttpPost]
        public IActionResult AddContract([FromBody] ContractEdit contractData)
        {
            try
            {
                var contractId = _contractInsertCommand.Add(contractData);
                return Ok(contractId);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
