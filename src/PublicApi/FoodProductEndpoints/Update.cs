using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Inventura.ApplicationCore.Entities;
using Inventura.ApplicationCore.Interfaces;

namespace Inventura.PublicApi.Util.FoodProductEndpoints
{
    [Authorize(Roles = "Administrators", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class Update : BaseAsyncEndpoint
        .WithRequest<UpdateFoodProductRequest>
        .WithResponse<UpdateFoodProductResponse>
    {
        private readonly IFoodProductService _foodProductService;
        private readonly IMapper _mapper;

        public Update(IFoodProductService foodProductService)
        {
            _foodProductService = foodProductService;
        }

        [HttpPut("api/food-product")]
        [SwaggerOperation(
            Summary = "Updates a Food Product",
            Description = "Updates a Food Product",
            OperationId = "food-product.update",
            Tags = new[] {"FoodProductEndpoints"})
        ]
        public override async Task<ActionResult<UpdateFoodProductResponse>> HandleAsync(
            UpdateFoodProductRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateFoodProductResponse(request.CorrelationId());

            var updatedFoodProduct = _foodProductService.PutAsync(
                new FoodProduct
                {
                    Id = request.Id,
                    Calories = request.Calories,
                    Carbohydrates = request.Carbohydrates,
                    Fats = request.Fats,
                    Name = request.Name,
                    Protein = request.Protein,
                    UnitOfMeasureId = request.UnitOfMeasureId
                });

            response.FoodProduct = _mapper.Map<FoodProductDto>(updatedFoodProduct);
            return response;
        }
    }
}