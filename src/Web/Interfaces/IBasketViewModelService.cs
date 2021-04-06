using System.Threading.Tasks;
using Microsoft.Inventura.Web.Pages.Basket;

namespace Microsoft.Inventura.Web.Interfaces
{
    public interface IBasketViewModelService
    {
        Task<BasketViewModel> GetOrCreateBasketForUser(string userName);
    }
}
