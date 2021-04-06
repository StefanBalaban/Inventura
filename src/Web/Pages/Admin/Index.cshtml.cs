using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Inventura.ApplicationCore.Constants;
using Microsoft.Inventura.Web.Extensions;
using Microsoft.Inventura.Web.Services;
using Microsoft.Inventura.Web.ViewModels;
using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;

namespace Microsoft.Inventura.Web.Pages.Admin
{
    [Authorize(Roles = BlazorShared.Authorization.Constants.Roles.ADMINISTRATORS)]
    public class IndexModel : PageModel
    {
        public IndexModel()
        {
           
        }
    }
}
