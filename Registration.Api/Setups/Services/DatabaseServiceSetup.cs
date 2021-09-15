using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Registration.Api.Setups.Factory.Services;
using Registration.Infrastructure.Data.ApplicationDbContext;

namespace Registration.Api.Setups.Services
{
    public class DatabaseServiceSetup :IServiceSetup
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>();
        }
    }
}
