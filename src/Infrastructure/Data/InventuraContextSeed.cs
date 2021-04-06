using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Inventura.Infrastructure.Data
{
    public class InventuraContextSeed
    {
        public static async Task SeedAsync(InventuraContext catalogContext,
            ILoggerFactory loggerFactory, int? retry = 0)
        {
            //int retryForAvailability = retry.Value;
            //try
            //{
            //    // TODO: Only run this if using a real database
            //    // catalogContext.Database.Migrate();
            //    if (!await catalogContext.CatalogBrands.AnyAsync())
            //    {
            //        await catalogContext.CatalogBrands.AddRangeAsync(
            //            GetPreconfiguredCatalogBrands());

            //        await catalogContext.SaveChangesAsync();
            //    }

            //    if (!await catalogContext.CatalogTypes.AnyAsync())
            //    {
            //        await catalogContext.CatalogTypes.AddRangeAsync(
            //            GetPreconfiguredCatalogTypes());

            //        await catalogContext.SaveChangesAsync();
            //    }

            //    if (!await catalogContext.CatalogItems.AnyAsync())
            //    {
            //        await catalogContext.CatalogItems.AddRangeAsync(
            //            GetPreconfiguredItems());

            //        await catalogContext.SaveChangesAsync();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    if (retryForAvailability < 10)
            //    {
            //        retryForAvailability++;
            //        var log = loggerFactory.CreateLogger<CatalogContextSeed>();
            //        log.LogError(ex.Message);
            //        await SeedAsync(catalogContext, loggerFactory, retryForAvailability);
            //    }
            //    throw;
            //}
        }
    }
}