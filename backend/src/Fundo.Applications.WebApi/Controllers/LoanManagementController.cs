using Fundo.Applications.Application.DTO;
using Fundo.Applications.Application.UseCases.Requests.Commands;
using Fundo.Applications.Application.UseCases.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Fundo.Applications.WebApi.Controllers
{
    [Route("/loan")]
    [ApiController]
    public class LoanManagementController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<LoanManagementController> _logger;
        public LoanManagementController(IMediator mediator, ILogger<LoanManagementController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        [HttpGet("{id:guid}")]
        [Authorize]
        public async Task<ActionResult> GetLoanById(Guid id)
        {
            var loan = await _mediator.Send(new GetLoanByIdRequest() { Id = id });
            return Ok(loan);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLoan([FromBody] LoanDTO loanDTO)
        {
            var command = new CreateLoanCommand
            {
                LoanDto = loanDTO
            };
            var result = await _mediator.Send(command);
            return Ok(result.Id);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllLoans()
        {
            var loans = await _mediator.Send(new GetAllLoanRequest());
            return Ok(loans);
        }

        [HttpPost("{id}/payment")]
        public async Task<IActionResult> MakePayment(Guid id, [FromBody] PaymentDTO amount)
        {
            var command = new MakeLoanPaymentCommand
            {
                LoanId = id,
                PaidAmount = amount.PaidAmount
            };

            var result = await _mediator.Send(command);
            if (!result)
                return NotFound($"Loan {id} not found or not active");

            return Ok("Payment applied.");
        }
    }
}