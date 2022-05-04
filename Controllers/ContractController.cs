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
        private IContractUpdateCommand _contractUpdateCommand;
        private IContractDeleteCommand _contractDeleteCommand;

        public ContractController(IContractGetCommand contractGetCommand,
            IContractInsertCommand contractInsertCommand,
            IContractUpdateCommand contractUpdateCommand, 
            IContractDeleteCommand contractDeleteCommand)
        {
            _contractGetCommand = contractGetCommand;
            _contractInsertCommand = contractInsertCommand;
            _contractUpdateCommand = contractUpdateCommand;
            _contractDeleteCommand = contractDeleteCommand;

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

        [HttpPost("InsertContract")]
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

        [HttpPost("UpdateContract")]
        public IActionResult UpdateContract([FromBody] ContractEdit contractData)
        {
            try
            {
                var contractID = _contractUpdateCommand.Update(contractData);
                return Ok(contractID);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("DeleteContract/{contractID}")]
        public IActionResult DeleteClient([FromRoute] int contractID)
        {
            try
            {
                var resultID = _contractDeleteCommand.Delete(contractID);
                return Ok(resultID);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
