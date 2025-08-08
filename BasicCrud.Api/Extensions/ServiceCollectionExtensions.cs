using BasicCrud.Api.Repositories;
using BasicCrud.Api.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BasicCrud.Api.Extensions
{
    /// <summary>
    /// Adds application services and repositories to DI.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IAddressService, AddressService>();

            return services;
        }
    }
}
