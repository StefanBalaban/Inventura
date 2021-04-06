using System;
using System.Collections.Generic;

namespace Inventura.PublicApi.Util.FoodProductEndpoints
{
    public class ListPagedFoodProductResponse : BaseResponse
    {
        public ListPagedFoodProductResponse(Guid correlationId) : base(correlationId)
        {
        }

        public ListPagedFoodProductResponse()
        {
        }

        public List<FoodProductDto> FoodProducts { get; set; } = new List<FoodProductDto>();
        public int PageCount { get; set; }
    }
}