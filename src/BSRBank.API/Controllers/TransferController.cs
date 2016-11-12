using System.Linq;
using BSRBank.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace BSRBank.API.Controllers
{
    [Route("accounts")]
    public class TransferController : Controller
    {
        [HttpPost("{bankAccountNumber}")]
        public IActionResult GetAccount( string bankAccountNumber, [FromBody] TransferModel transferModel )
        {
            if ( !AccountValidator.ValidateAccount(bankAccountNumber) )
                return NotFound(new { error = $"Wrong destination account number: {bankAccountNumber}" });

            if ( !AccountValidator.ValidateAccount(transferModel.From) )
                return NotFound(new { error = $"Wrong source account number: {transferModel.From}" });

            if ( bankAccountNumber == transferModel.From ) ModelState.AddModelError("AccountNumber", "Source and destination bank account number cannot be the same.");

            if ( !ModelState.IsValid )
            {
                return BadRequest(new
                {
                    error = string.Join("; ", ModelState.Values.SelectMany(m => m.Errors)
                    .Select(e => e.ErrorMessage))
                });
            }
            return StatusCode(201);
        }
    }
}
