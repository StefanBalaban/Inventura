using Ardalis.GuardClauses;

namespace ApplicationCore.Entities.MealAggregate
{
    public class MealItem : BaseEntity
    {
        public FoodProduct FoodProduct { get; private set; }
        public float Amount { get; private set; }

        public MealItem()
        {
        }

        public MealItem(FoodProduct foodProduct, float amount)
        {
            Guard.Against.Null(foodProduct, nameof(foodProduct));
            Guard.Against.Zero(amount, nameof(amount));

            FoodProduct = foodProduct;
            Amount = amount;
        }

        public void EditMeal(FoodProduct foodProduct, float amount)
        {
            Guard.Against.Null(foodProduct, nameof(foodProduct));
            Guard.Against.Zero(amount, nameof(amount));

            FoodProduct = foodProduct;
            Amount = amount;
        }
    }
}