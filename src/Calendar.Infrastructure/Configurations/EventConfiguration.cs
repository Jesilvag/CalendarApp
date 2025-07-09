using Calendar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Calendar.Infrastructure.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<CalendarEvent>
    {
        public void Configure(EntityTypeBuilder<CalendarEvent> builder)
        {
            builder.HasKey(e => e.Id);
        }
    }
}
