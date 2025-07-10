using AutoMapper;
using Calendar.Application.Abstractions;
using Calendar.Application.DTOs;
using MediatR;

namespace Calendar.Application.Queries.Events
{
    public class GetEventByDateHandler : IRequestHandler<GetEventQueryByDate, IEnumerable<CalendarEventDto>>
    {
        private readonly IEventRepository _repo;
        private readonly IMapper _mapper;

        public GetEventByDateHandler(IEventRepository repository, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repo = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IEnumerable<CalendarEventDto>> Handle(GetEventQueryByDate request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            // Assuming _repo has a method to fetch events by date
            var events = await _repo.GetEventsByDateAsync(request.Date, cancellationToken);

            return _mapper.Map<IEnumerable<CalendarEventDto>>(events);
        }
    }
}
