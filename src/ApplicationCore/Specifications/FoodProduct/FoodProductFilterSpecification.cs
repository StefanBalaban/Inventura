using Ardalis.Specification;

namespace Inventura.ApplicationCore.Specifications.FoodProduct
{
    public class FoodProductFilterSpecification : Specification<Entities.FoodProduct>
    {
        public FoodProductFilterSpecification(int? unitOfMeasureId,
            float? caloriesLTE,
            float? caloriesGTE,
            float? protein)
        {
            Query
                .Where(i => !unitOfMeasureId.HasValue || i.UnitOfMeasureId == unitOfMeasureId)
                .Where(i => !caloriesLTE.HasValue || i.Calories <= caloriesLTE)
                .Where(i => !caloriesGTE.HasValue || i.Calories >= caloriesGTE)
                .Where(i => !protein.HasValue || i.Protein == protein);
        }
    }
}