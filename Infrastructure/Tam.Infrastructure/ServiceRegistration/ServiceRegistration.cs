using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tam.Application.Interfaces.Services;
using Tam.Application.Services;
using Tam.Infrastructure.Mapping;
using Tam.Infrastructure.Services;

namespace Tam.Infrastructure.ServiceRegistration
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {


            services.AddAutoMapper(typeof(UserMapping).Assembly);
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IAppranteeService, AppranteeService>();




            return services;
        }
    }
}
