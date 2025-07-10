using Calendar.Application.Abstractions;
using Calendar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Calendar.Infrastructure.Persistence;

public sealed class EventRepository(ApplicationContext ctx) : IEventRepository
{
    private readonly ApplicationContext _ctx = ctx;

    public Task AddAsync(CalendarEvent entity, CancellationToken ct = default) =>
        _ctx.AddAsync(entity, ct).AsTask();

    public async Task<CalendarEvent> GetByIdAsync(int id, CancellationToken ct)
    {
        return await _ctx.Events.FirstOrDefaultAsync(e => e.Id == id, ct)
            ?? throw new KeyNotFoundException($"Event with ID {id} not found.");
    }

    public Task<int> SaveChangesAsync(CancellationToken ct = default) =>
        _ctx.SaveChangesAsync(ct);

    public async Task<IReadOnlyList<CalendarEvent>> GetEventsByDateAsync(DateOnly date, CancellationToken ct = default)
    {
        return await _ctx.Events.Where(e => e.StartDate == date || e.EndDate == date).ToListAsync(ct);
    }
}

