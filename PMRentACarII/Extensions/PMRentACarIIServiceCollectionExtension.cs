using PMRentACarII.Core.Contracts;
using PMRentACarII.Core.Contracts.Admin;
using PMRentACarII.Core.Exceptions;
using PMRentACarII.Core.Services;
using PMRentACarII.Core.Services.Admin;
using PMRentACarII.Infrastructure.Data.Common;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class PMRentACarIIServiceCollectionExtension
    {
        /// <summary>
        /// extending IServiceCollection and adding more services into the inversion of control container
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IAgentService, AgentService>();
            services.AddScoped<IGuard, Guard>();
            services.AddScoped<IDriverService, DriverService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAdminDriverService, AdminDriverService>();
            services.AddScoped<IRentService, RentService>();


            return services;
        }
    }
}
