using System;
using Inventura.PublicApi.Util.FoodProductEndpoints;

namespace Inventura.PublicApi.Util.CatalogItemEndpoints
{
    public class CreateFoodProductResponse : BaseResponse
    {
        public CreateFoodProductResponse(Guid correlationId) : base(correlationId)
        {
        }

        public CreateFoodProductResponse()
        {
        }

        public FoodProductDto FoodProduct { get; set; }
    }
}