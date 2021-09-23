using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Registration.UI.Setups.Factory.Services;

namespace Registration.UI.Setups.Services
{
    public class BaseRepositorySetup : IServiceSetup
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            //services.AddTransient(typeof(IBaseRepository<>),typeof(BaseRepository<>));
        }
    }
}
