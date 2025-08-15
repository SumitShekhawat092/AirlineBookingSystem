using AirlineBookingSystem.Notifications.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirlineBookingSystem.Notifications.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public NotificationController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> SendNotification([FromBody] SendNotificationCommand command)
        { 
            await _mediator.Send(command);
            return Ok();
        }

    }
}
