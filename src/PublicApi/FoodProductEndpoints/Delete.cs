using Ardalis.ApiEndpoints;
using Inventura.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace Inventura.PublicApi.Util.FoodProductEndpoints
{
    [Authorize(Roles = "Administrators", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class Delete : BaseAsyncEndpoint
        .WithRequest<DeleteFoodProductRequest>
        .WithResponse<DeleteFoodProductResponse>
    {
        private readonly IFoodProductService _foodProductService;

        public Delete(IFoodProductService foodProductService)
        {
            _foodProductService = foodProductService;
        }

        [HttpDelete("api/food-product/{FoodProductId}")]
        [SwaggerOperation(
            Summary = "Deletes a Food Product",
            Description = "Deletes a Food Product",
            OperationId = "food-product.Delete",
            Tags = new[] { "FoodProductEndpoints" })
        ]
        public override async Task<ActionResult<DeleteFoodProductResponse>> HandleAsync(
            [FromRoute] DeleteFoodProductRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteFoodProductResponse(request.CorrelationId());

            await _foodProductService.DeleteAsync(request.FoodProductId);

            return Ok(response);
        }
    }
}