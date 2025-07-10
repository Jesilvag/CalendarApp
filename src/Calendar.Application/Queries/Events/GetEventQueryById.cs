using Calendar.Application.DTOs;
using MediatR;

namespace Calendar.Application.Queries.Events;

public record GetEventQueryById(int Id) : IRequest<CalendarEventDto>;
