using Ardalis.GuardClauses;
using System;

namespace Inventura.ApplicationCore.Entities
{
    public class FoodStock : BaseEntity
    {
        public FoodProduct FoodProduct { get; private set; }
        public float Amount { get; private set; }
        public float? UpperAmount { get; private set; }
        public float? LowerAmount { get; private set; }
        public DateTime? DateOfPurchase { get; private set; }
        public DateTime? BestUseByDate { get; set; }

        public FoodStock()
        {
        }

        public FoodStock(FoodProduct foodProduct,
            float amount,
            float upperAmount,
            float lowerAmount,
            DateTime? dateOfPurchase,
            DateTime? bestUseByDate)
        {
            Guard.Against.Null(foodProduct, nameof(foodProduct));
            Guard.Against.Negative(amount, nameof(amount));
            Guard.Against.Negative(upperAmount, nameof(upperAmount));
            Guard.Against.Negative(lowerAmount, nameof(lowerAmount));

            FoodProduct = foodProduct;
            Amount = amount;
            UpperAmount = upperAmount;
            LowerAmount = lowerAmount;
            DateOfPurchase = dateOfPurchase;
            BestUseByDate = bestUseByDate;
        }

        public void EditAmount(float amount, DateTime? dateOfPurchase, DateTime? bestUseByDate)
        {
            Guard.Against.Negative(amount, nameof(amount));

            Amount = amount;
            DateOfPurchase = dateOfPurchase;
            BestUseByDate = bestUseByDate;
        }

        public void EditAmountLimits(float upperAmount, float lowerAmount)
        {
            Guard.Against.Negative(upperAmount, nameof(upperAmount));
            Guard.Against.Negative(lowerAmount, nameof(lowerAmount));

            UpperAmount = upperAmount;
            LowerAmount = lowerAmount;
        }

        public void EditDateOfPurchase(DateTime dateOfPurchase)
        {
            DateOfPurchase = dateOfPurchase;
        }

        public void EditBestUseByDate(DateTime bestUseByDate)
        {
            BestUseByDate = bestUseByDate;
        }
    }
}