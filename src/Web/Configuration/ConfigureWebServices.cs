using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Inventura.Web.Interfaces;
using Microsoft.Inventura.Web.Services;

namespace Microsoft.Inventura.Web.Configuration
{
    public static class ConfigureWebServices
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(BasketViewModelService).Assembly);
            services.AddScoped<IBasketViewModelService, BasketViewModelService>();
            services.AddScoped<CatalogViewModelService>();
            services.AddScoped<ICatalogItemViewModelService, CatalogItemViewModelService>();
            services.Configure<CatalogSettings>(configuration);
            services.AddScoped<ICatalogViewModelService, CachedCatalogViewModelService>();

            return services;
        }
    }
}
