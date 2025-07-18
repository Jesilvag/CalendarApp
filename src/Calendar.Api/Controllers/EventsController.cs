using Calendar.Application.Commands.Events;
using Calendar.Application.DTOs;
using Calendar.Application.Queries.Events;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Calendar.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventsController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    // POST /api/events  – create (Write model)
    [HttpPost]
    public async Task<ActionResult<int>> Create(
        [FromBody] AddEventCommand request,
        CancellationToken ct)
    {
        var id = await _mediator.Send(request, ct);
        return Ok(id);
    }

    // GET /api/events/{id}
    [HttpGet("{id:int}")]
    public async Task<ActionResult<CalendarEventDto>> Get(int id, CancellationToken ct)
    {
        var evt = await _mediator.Send(new GetEventQueryById(id), ct);
        return evt is null ? NotFound() : Ok(evt);
    }

    // Get /api/events?date=2025-07-01
    [HttpGet()]
    public async Task<ActionResult<IEnumerable<CalendarEventDto>>> GetByDate([FromQuery] DateOnly date, CancellationToken ct)
    {
        var events = await _mediator.Send(new GetEventQueryByDate(date), ct);
        return Ok(events);
    }


    // put /api/events/{id}
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id,
        [FromBody] UpdateEventCommand request,
        CancellationToken ct)
    {
        request.Id = id;
        var result = await _mediator.Send(request, ct);
        return Ok(result);
    }
}
