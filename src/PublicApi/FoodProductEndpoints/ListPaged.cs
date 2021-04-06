using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Inventura.ApplicationCore.Interfaces;
using Inventura.ApplicationCore.Specifications.FoodProduct;
using Inventura.ApplicationCore.Entities;
using Inventura.ApplicationCore.Extensions;

namespace Inventura.PublicApi.Util.FoodProductEndpoints
{
    public class ListPaged : BaseAsyncEndpoint
        .WithRequest<ListPagedFoodProductRequest>
        .WithResponse<ListPagedFoodProductResponse>
    {
        private readonly IFoodProductService _foodProductService;
        private readonly IMapper _mapper;

        public ListPaged(IFoodProductService foodProductService,
            IMapper mapper)
        {
            _foodProductService = foodProductService;
            _mapper = mapper;
        }

        [HttpGet("api/food-product")]
        [SwaggerOperation(
            Summary = "List Food Products (paged)",
            Description = "List Food Products (paged)",
            OperationId = "food-product.ListPaged",
            Tags = new[] {"FoodProductEndpoints"})
        ]
        public override async Task<ActionResult<ListPagedFoodProductResponse>> HandleAsync(
            [FromQuery] ListPagedFoodProductRequest request, CancellationToken cancellationToken)
        {
            var response = new ListPagedFoodProductResponse(request.CorrelationId());

            var filterSpec = new FoodProductFilterSpecification(
                request.UnitOfMeasureId,
                request.CaloriesLTE,
                request.CaloriesGTE,
                request.Protein);

            var pagedSpec = new FoodProductFilterPaginatedSpecification(
                request.PageIndex * request.PageSize,
                request.PageSize,
                request.UnitOfMeasureId,
                request.CaloriesLTE,
                request.CaloriesGTE,
                request.Protein
            );

            var foodProducts = await _foodProductService.GetAsync(filterSpec, pagedSpec);

            response.FoodProducts.AddRange(foodProducts.List.Select(_mapper.Map<FoodProductDto>));
            response.PageCount = int.Parse(Math.Ceiling((decimal) foodProducts.Count / request.PageSize).ToString());

            return Ok(response);
        }
    }
}