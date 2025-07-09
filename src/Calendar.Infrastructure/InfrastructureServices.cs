using Calendar.Application.Abstractions;
using Calendar.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Calendar.Infrastructure
{
    public static class InfrastructureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseInMemoryDatabase(connectionString);
            });

            return services;
        }
    }
}
