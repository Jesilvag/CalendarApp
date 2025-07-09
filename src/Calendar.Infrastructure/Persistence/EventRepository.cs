using Calendar.Application.Abstractions;
using Calendar.Domain.Entities;

namespace Calendar.Infrastructure.Persistence;

public sealed class EventRepository(ApplicationContext ctx) : IEventRepository
{
    private readonly ApplicationContext _ctx = ctx;

    public Task AddAsync(CalendarEvent entity, CancellationToken ct = default) =>
        _ctx.AddAsync(entity, ct).AsTask();

    public Task<int> SaveChangesAsync(CancellationToken ct = default) =>
        _ctx.SaveChangesAsync(ct);
}

