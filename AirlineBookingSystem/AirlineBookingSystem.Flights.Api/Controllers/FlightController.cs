using AirlineBookingSystem.Flights.Application.Commands;
using AirlineBookingSystem.Flights.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirlineBookingSystem.Flights.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FlightController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetFlights()
        {
            var flights = await _mediator.Send(new GetAllFlightsQuery());
            return Ok(flights);
        }

        [HttpPost]
        public async Task<IActionResult> AddFlight([FromBody] CreateFlightCommand command)
        { 
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetFlights), new { id }, command);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlight(Guid id)
        { 
            await _mediator.Send(new DeleteFlightCommand(id));
            return NoContent();
        }
    }
}
