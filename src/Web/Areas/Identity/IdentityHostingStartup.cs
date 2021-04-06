using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Microsoft.Inventura.Web.Areas.Identity.IdentityHostingStartup))]
namespace Microsoft.Inventura.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}