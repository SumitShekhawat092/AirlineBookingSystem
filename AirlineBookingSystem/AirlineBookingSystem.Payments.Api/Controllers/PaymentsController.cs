using AirlineBookingSystem.Payments.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirlineBookingSystem.Payments.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PaymentsController(IMediator mediator) => _mediator = mediator;
        [HttpPost]
        public async Task<IActionResult> ProcessPayment([FromBody] ProcessPaymentCommand command)
        { 
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(ProcessPayment), new { id }, command);
        }
        [HttpPost("refund/{id}")]
        public async Task<IActionResult> RefundPayment(Guid id)
        {
            await _mediator.Send(new RefundPaymentCommand(id));
            return NoContent();
        }
    }
}
