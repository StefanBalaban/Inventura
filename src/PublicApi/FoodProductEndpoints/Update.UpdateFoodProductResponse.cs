using System;

namespace Inventura.PublicApi.Util.FoodProductEndpoints
{
    public class UpdateFoodProductResponse : BaseResponse
    {
        public UpdateFoodProductResponse(Guid correlationId) : base(correlationId)
        {
        }

        public UpdateFoodProductResponse()
        {
        }

        public FoodProductDto FoodProduct { get; set; }
    }
}