using Calendar.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Application.Queries.Events
{
    public class GetEventQueryByDate : IRequest<IEnumerable<CalendarEventDto>>
    {
        public DateOnly Date { get; }

        public GetEventQueryByDate(DateOnly date)
        {
            Date = date;
        }
    }
}
