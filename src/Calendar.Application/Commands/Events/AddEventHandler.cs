using Calendar.Application.Abstractions;
using Calendar.Domain.Entities;
using MediatR;

namespace Calendar.Application.Commands.Events
{
    public class AddEventHandler(IEventRepository repository) : IRequestHandler<AddEventCommand, int>
    {
        private readonly IEventRepository _repository = repository;

        public async Task<int> Handle(AddEventCommand command, CancellationToken cancellationToken)
        {
            var entity = new CalendarEvent
            {
                StartDate = command.StartDate,
                EndDate = command.EndDate,
                Title = command.Title,
                Description = command.Description,
                Location = command.Location
            };
            await _repository.AddAsync(entity, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
