using Calendar.Domain.Entities;

namespace Calendar.Application.Abstractions;

public interface IEventRepository
{
    Task AddAsync(CalendarEvent entity, CancellationToken ct = default);
    Task<CalendarEvent> GetByIdAsync(int id, CancellationToken ct);
    Task<int> SaveChangesAsync(CancellationToken ct = default);

    Task<IReadOnlyList<CalendarEvent>> GetEventsByDateAsync(DateOnly date, CancellationToken ct = default);
}

