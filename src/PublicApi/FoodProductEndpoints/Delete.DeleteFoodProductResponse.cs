using System;

namespace Inventura.PublicApi.Util.CatalogItemEndpoints
{
    public class DeleteFoodProductResponse : BaseResponse
    {
        public DeleteFoodProductResponse(Guid correlationId) : base(correlationId)
        {
        }

        public DeleteFoodProductResponse()
        {
        }

        public string Status { get; set; } = "Deleted";
    }
}