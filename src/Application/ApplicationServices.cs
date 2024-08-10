using Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(opt => opt.RegisterServicesFromAssembly((Assembly.GetExecutingAssembly())));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddInfrastructureServices("CalendarDb");
            return services;
        }
    }
}
