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
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<IDriverService, DriverService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IRegionService, RegionService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<IGuideService, GuideService>();




            return services;
        }
    }
}
