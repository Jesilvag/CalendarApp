using Calendar.Application.Commands.Events;
using Calendar.Application.DTOs;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Calendar.Web.Api;

public interface IEventsApi
{
    [Post("/events")]
    Task<int> CreateAsync([Body] AddEventCommand request);

    [Get("/events/{id}")]
    Task<CalendarEventDto> GetAsync(int id);

    //[Get("/events")]
    //Task<IEnumerable<CalendarEventDto>> SearchAsync(
    //    [Query] DateOnly? from = null,
    //    [Query] DateOnly? to = null);

    //[Delete("/events/{id}")]
    //Task DeleteAsync(int id);

    [Get("/events")]
    Task<IEnumerable<CalendarEventDto>> GetByDateAsync([Query] DateOnly date);
}
