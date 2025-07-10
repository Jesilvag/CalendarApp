using AutoMapper;
using Calendar.Application.Abstractions;
using Calendar.Application.DTOs;
using Calendar.Application.Queries.Events;
using MediatR;

namespace Calendar.Application.Commands.Events
{
    public sealed class GetEventQueryByIdHandler : IRequestHandler<GetEventQueryById, CalendarEventDto?>
    {
        private readonly IEventRepository _repo;
        private readonly IMapper _mapper;

        public GetEventQueryByIdHandler(IEventRepository repo, IMapper mapper)
            => (_repo, _mapper) = (repo, mapper);

        public async Task<CalendarEventDto?> Handle(GetEventQueryById q, CancellationToken ct)
        {
            var entity = await _repo.GetByIdAsync(q.Id, ct);
            return entity is null ? null : _mapper.Map<CalendarEventDto>(entity);
        }
    }
}