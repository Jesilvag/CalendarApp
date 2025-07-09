using Calendar.Domain.Entities;

namespace Calendar.Application.Abstractions;

public interface IEventRepository
{
    Task AddAsync(CalendarEvent entity, CancellationToken ct = default);
    Task<int> SaveChangesAsync(CancellationToken ct = default);
}

