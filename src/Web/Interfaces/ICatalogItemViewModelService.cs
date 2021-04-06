using System.Threading.Tasks;
using Microsoft.Inventura.Web.ViewModels;

namespace Microsoft.Inventura.Web.Interfaces
{
    public interface ICatalogItemViewModelService
    {
        Task UpdateCatalogItem(CatalogItemViewModel viewModel);
    }
}
