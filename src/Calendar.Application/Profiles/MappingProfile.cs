using AutoMapper;
using Calendar.Application.DTOs;
using Calendar.Domain.Entities;

namespace Calendar.Api.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CalendarEvent, CalendarEventDto>();
        }
    }
}
