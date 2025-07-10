using Calendar.Application.Commands.Events;
using Calendar.Application.DTOs;
using Calendar.Application.Queries.Events;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Calendar.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{
    private readonly IMediator _mediator;
    public EventsController(IMediator mediator) => _mediator = mediator;

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

    // Get /api/events?date=2025-07-01  – get events by date
    [HttpGet()]
    public async Task<ActionResult<IEnumerable<CalendarEventDto>>> GetByDate([FromQuery] DateOnly date, CancellationToken ct)
    {
        var events = await _mediator.Send(new GetEventQueryByDate(date), ct);
        return Ok(events);
    }

    //// GET /api/events?from=2025-07-01&to=2025-07-31  – search window
    //[HttpGet]
    //public Task<IEnumerable<CalendarEventDto>> Search(
    //    [FromQuery] DateOnly? from,
    //    [FromQuery] DateOnly? to,
    //    CancellationToken ct) =>
    //    _mediator.Send(new SearchEventsQuery(from, to), ct);

    //// PUT /api/events/{id}  – update basic fields
    //[HttpPut("{id:int}")]
    //public Task<IActionResult> Update(int id,
    //    [FromBody] UpdateEventRequest request,
    //    CancellationToken ct) =>
    //    _mediator.Send(new UpdateEventCommand(id, request), ct)
    //             .ContinueWith(_ => NoContent(), ct);

    //// DELETE /api/events/{id}
    //[HttpDelete("{id:int}")]
    //public Task<IActionResult> Delete(int id, CancellationToken ct) =>
    //    _mediator.Send(new DeleteEventCommand(id), ct)
    //             .ContinueWith(_ => NoContent(), ct);
}
