using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Registration.Infrastructure.Data.ApplicationDbContext;
using Registration.UI.Setups.Factory.Services;

namespace Registration.UI.Setups.Services
{
    public class DatabaseServiceSetup :IServiceSetup
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>();
        }
    }
}
