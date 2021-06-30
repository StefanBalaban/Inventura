using Bogus;
using Bogus.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Inventura.Infrastructure.Data
{
    public class InventuraContextSeed
    {
        public static async Task SeedAsync(InventuraContext catalogContext,
            ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                // TODO: Only run this if using a real database
                // catalogContext.Database.Migrate();
                if (!await catalogContext.UnitOfMeasures.AnyAsync())
                {
                    await catalogContext.UnitOfMeasures.AddRangeAsync(
                        new ApplicationCore.Entities.UnitOfMeasure(1));

                    await catalogContext.SaveChangesAsync();
                }
                if (!await catalogContext.FoodProducts.AnyAsync())
                {
                    var ids = 1;
                    await catalogContext.FoodProducts.AddRangeAsync(
                        new Faker<ApplicationCore.Entities.FoodProduct>().RuleFor(m => m.Id, f => ids++).RuleFor(m => m.UnitOfMeasureId, f => 1).GenerateBetween(12, 12));

                    await catalogContext.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<InventuraContextSeed>();
                    log.LogError(ex.Message);
                    await SeedAsync(catalogContext, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }
    }
}