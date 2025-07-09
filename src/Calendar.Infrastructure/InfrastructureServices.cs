using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Calendar.Infrastructure
{
    public static class InfrastructureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseInMemoryDatabase(connectionString);
            });

            return services;
        }
    }
}
