using Ardalis.ApiEndpoints;
using AutoMapper;
using Inventura.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace Inventura.PublicApi.Util.FoodProductEndpoints
{
    public class GetById : BaseAsyncEndpoint
        .WithRequest<GetByIdFoodProductRequest>
        .WithResponse<GetByIdFoodProductResponse>
    {
        private readonly IFoodProductService _foodProduct;
        private readonly IMapper _mapper;

        public GetById(IFoodProductService foodProduct, IMapper mapper)
        {
            _foodProduct = foodProduct;
            _mapper = mapper;
        }

        [HttpGet("api/food-product/{FoodProductId}")]
        [SwaggerOperation(
            Summary = "Get a Food Product by Id",
            Description = "Gets a Food Product by Id",
            OperationId = "catalog-items.GetById",
            Tags = new[] { "FoodProductEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdFoodProductResponse>> HandleAsync(
            [FromRoute] GetByIdFoodProductRequest request, CancellationToken cancellationToken)
        {
            var response = new GetByIdFoodProductResponse(request.CorrelationId());

            var foodProduct = await _foodProduct.GetAsync(request.FoodProductId);

            response.FoodProduct = _mapper.Map<FoodProductDto>(foodProduct);

            return Ok(response);
        }
    }
}