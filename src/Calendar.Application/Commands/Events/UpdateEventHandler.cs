using AutoMapper;
using Calendar.Application.Abstractions;
using Calendar.Application.DTOs;
using MediatR;

namespace Calendar.Application.Commands.Events
{
    public class UpdateEventHandler(IEventRepository eventRepository, IMapper mapper) : IRequestHandler<UpdateEventCommand, CalendarEventDto>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IEventRepository _eventRepository = eventRepository;

        public async Task<CalendarEventDto> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var entity = await _eventRepository.GetByIdAsync(request.Id, cancellationToken) ?? throw new ArgumentException($"Event {request.Id} not found");
            entity.Location = request.Location;
            entity.StartDate = request.StartDate;
            entity.EndDate = request.EndDate;
            entity.Description = request.Description;
            entity.Title = request.Title;
            await _eventRepository.SaveChangesAsync(cancellationToken);
            return _mapper.Map<CalendarEventDto>(entity);
        }
    }
}
