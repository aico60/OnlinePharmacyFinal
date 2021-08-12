using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Online_Pharmacy.Areas.Identity.IdentityHostingStartup))]
namespace Online_Pharmacy.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}