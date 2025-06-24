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
            services.AddScoped<IRouteService, RouteService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IFacilityService, FacilityService>();
            services.AddScoped<IHotelService, HotelService>();
            services.AddScoped<ITransferService, TransferService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IPaymentMethodService, PaymentMethodService>();
            services.AddScoped<IRoomTypeService, RoomTypeService>();
            services.AddScoped<IHotelRoomOptionService, HotelRoomOptionService>();
            services.AddScoped<IDiscountService, DiscountService>();
            services.AddScoped<IHotelReservationService, HotelReservationService>();




            return services;
        }
    }
}
