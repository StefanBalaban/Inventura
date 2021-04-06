using Microsoft.AspNetCore.Mvc;

namespace Inventura.PublicApi.Util.FoodProductEndpoints
{
    public class DeleteFoodProductRequest : BaseRequest
    {
        //[FromRoute]
        public int FoodProductId { get; set; }
    }
}