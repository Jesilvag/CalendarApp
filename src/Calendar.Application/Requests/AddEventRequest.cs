using MediatR;

namespace Calendar.Application.Requests
{
    public class AddEventRequest : IRequest<int>
    {
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
    }
}
