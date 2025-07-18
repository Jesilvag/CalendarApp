using Calendar.Application.Commands.Events;
using Calendar.Application.DTOs;
using Refit;

namespace Calendar.Web.Api;

public interface IEventsApi
{
    [Post("/events")]
    Task<int> CreateAsync([Body] AddEventCommand request);

    [Get("/events/{id}")]
    Task<CalendarEventDto> GetAsync(int id);

    [Get("/events")]
    Task<IEnumerable<CalendarEventDto>> GetByDateAsync([Query] DateOnly date);

    [Put("/events/{id}")]
    Task<CalendarEventDto> UpdateAsync(int id, [Body] UpdateEventCommand request);
}
