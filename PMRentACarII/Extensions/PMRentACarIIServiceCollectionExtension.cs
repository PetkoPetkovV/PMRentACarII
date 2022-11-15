using PMRentACarII.Core.Contracts;
using PMRentACarII.Core.Services;
using PMRentACarII.Infrastructure.Data.Common;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class PMRentACarIIServiceCollectionExtension
    {
        /// <summary>
        /// adding services into the inversion of control container
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<ICarService, CarService>();

            return services;
        }
    }
}
