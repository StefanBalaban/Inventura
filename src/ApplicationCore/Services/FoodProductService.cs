using Ardalis.GuardClauses;
using Ardalis.Specification;
using Inventura.ApplicationCore.Entities;
using Inventura.ApplicationCore.Extensions;
using Inventura.ApplicationCore.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventura.ApplicationCore.Services
{
    public class FoodProductService : IFoodProductService
    {
        private readonly IAsyncRepository<FoodProduct> _foodProductRepository;
        private readonly IAppLogger<FoodProductService> _logger;

        public FoodProductService(IAsyncRepository<FoodProduct> foodProductRepository,
            IAppLogger<FoodProductService> logger)
        {
            _foodProductRepository = foodProductRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<FoodProduct>> GetAsync()
        {
            return await _foodProductRepository.ListAllAsync();
        }

        public async Task<ListEntity<FoodProduct>> GetAsync(Specification<FoodProduct> filterSpec,
            Specification<FoodProduct> pagedSpec)
        {
            return new ListEntity<FoodProduct>
            {
                List = await _foodProductRepository.ListAsync(pagedSpec),
                Count = await _foodProductRepository.CountAsync(filterSpec)
            };
        }


        public async Task<FoodProduct> GetAsync(int id)
        {
            var foodProduct = await _foodProductRepository.GetByIdAsync(id);
            Guard.Against.EntityNotFound(foodProduct, nameof(FoodProduct));

            return foodProduct;
        }

        public async Task<FoodProduct> PostAsync(FoodProduct t)
        {
            Guard.Against.ModelStateIsInvalid(t, nameof(FoodProduct));

            return await _foodProductRepository.AddAsync(
                new FoodProduct
                {
                    Name = t.Name,
                    Calories = t.Calories,
                    Carbohydrates = t.Carbohydrates,
                    Fats = t.Fats,
                    Protein = t.Protein,
                    UnitOfMeasureId = t.UnitOfMeasureId
                }
            );
        }

        public async Task<FoodProduct> PutAsync(FoodProduct t)
        {
            Guard.Against.ModelStateIsInvalid(t, nameof(FoodProduct));

            var foodProduct = await _foodProductRepository.GetByIdAsync(t.Id);
            Guard.Against.EntityNotFound(foodProduct, nameof(FoodProduct));

            foodProduct.Name = t.Name;
            foodProduct.Calories = t.Calories;
            await _foodProductRepository.UpdateAsync(foodProduct);

            return foodProduct;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var foodProduct = await _foodProductRepository.GetByIdAsync(id);
            Guard.Against.EntityNotFound(foodProduct, nameof(FoodProduct));
            await _foodProductRepository.DeleteAsync(foodProduct);

            return true;
        }
    }
}