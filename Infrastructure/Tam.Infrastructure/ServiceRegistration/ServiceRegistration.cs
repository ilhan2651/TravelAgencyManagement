using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tam.Infrastructure.Mapping;

namespace Tam.Infrastructure.ServiceRegistration
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {


            services.AddAutoMapper(typeof(UserMapping).Assembly);
            




            return services;
        }
    }
}
