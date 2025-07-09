using Calendar.Application.Requests;
using Calendar.Domain.Entities;
using Calendar.Infrastructure;
using MediatR;

namespace Calendar.Application.Commands
{
    public class AddEvent : IRequestHandler<AddEventRequest, int>
    {
        private readonly ApplicationContext _context;
        public AddEvent(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(AddEventRequest request, CancellationToken cancellationToken)
        {
            var entity = new Event
            {
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Title = request.Title,
                Description = request.Description,
                Location = request.Location
            };
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }
    }
}
