using Calendar.Application.Abstractions;
using Calendar.Application.Requests;
using Calendar.Domain.Entities;
using MediatR;

namespace Calendar.Application.Commands
{
    public class AddEventHandler(IEventRepository repository) : IRequestHandler<AddEventRequest, int>
    {
        private readonly IEventRepository _repository = repository;

        public async Task<int> Handle(AddEventRequest request, CancellationToken cancellationToken)
        {
            var entity = new CalendarEvent
            {
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Title = request.Title,
                Description = request.Description,
                Location = request.Location
            };
            await _repository.AddAsync(entity, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
