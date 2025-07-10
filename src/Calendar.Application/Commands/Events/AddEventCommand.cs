using MediatR;

namespace Calendar.Application.Commands.Events
{
    public class AddEventCommand : IRequest<int>
    {
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
    }
}
