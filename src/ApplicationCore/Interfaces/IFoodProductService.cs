using System.Threading.Tasks;
using Inventura.ApplicationCore.Entities;
using Inventura.ApplicationCore.Specifications.FoodProduct;

namespace Inventura.ApplicationCore.Interfaces
{
    public interface IFoodProductService : ICrudServices<FoodProduct>
    {
    }
}