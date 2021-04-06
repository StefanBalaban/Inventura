using Ardalis.Specification;
using Inventura.ApplicationCore.Entities;

namespace Inventura.ApplicationCore.Specifications.FoodProduct
{
    public class FoodProductFilterPaginatedSpecification : Specification<Entities.FoodProduct>
    {
        public FoodProductFilterPaginatedSpecification(int skip, 
            int take, 
            int? unitOfMeasureId,
            float? caloriesLTE,
            float? caloriesGTE,
            float? protein)
        {
            Query
                .Where(i => !unitOfMeasureId.HasValue || i.UnitOfMeasureId == unitOfMeasureId)
                .Where(i => !caloriesLTE.HasValue || i.Calories <= caloriesLTE)
                .Where(i => !caloriesGTE.HasValue || i.Calories >= caloriesGTE)
                .Where(i => !protein.HasValue || i.Protein == protein)
                .Skip(skip)
                .Take(take)
                .Include(x => x.UnitOfMeasure);
        }
    }
}