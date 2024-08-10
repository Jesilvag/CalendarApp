using MediatR;

namespace Application.Requests
{
    public class AddEventRequest: IRequest<int>
    {
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string Title { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string Location { get; set; } = String.Empty;
    }
}
