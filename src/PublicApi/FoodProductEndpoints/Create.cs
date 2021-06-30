using Ardalis.ApiEndpoints;
using AutoMapper;
using Inventura.ApplicationCore.Entities;
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
    public class Create : BaseAsyncEndpoint
        .WithRequest<CreateFoodProductRequest>
        .WithResponse<CreateFoodProductResponse>
    {
        private readonly IFoodProductService _foodProductService;
        private readonly IMapper _mapper;

        public Create(IFoodProductService foodProductService, IMapper mapper)
        {
            _foodProductService = foodProductService;
            _mapper = mapper;
        }

        [HttpPost("api/food-product")]
        [SwaggerOperation(
            Summary = "Creates a new Food Product",
            Description = "Creates a new Food Product",
            OperationId = "food-product.create",
            Tags = new[] { "FoodProductEndpoints" })
        ]
        public override async Task<ActionResult<CreateFoodProductResponse>> HandleAsync(
            CreateFoodProductRequest request, CancellationToken cancellationToken)
        {
            var response = new CreateFoodProductResponse(request.CorrelationId());
            var newFoodProduct = await _foodProductService.PostAsync(new FoodProduct
            {
                Name = request.Name,
                Calories = request.Calories,
                Carbohydrates = request.Carbohydrates,
                Fats = request.Fats,
                Protein = request.Protein,
                UnitOfMeasureId = request.UnitOfMeasureId
            });

            response.FoodProduct = _mapper.Map<FoodProductDto>(newFoodProduct); ;

            return response;
        }
    }
}