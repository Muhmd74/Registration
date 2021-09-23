using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Registration.UI.Setups.Factory.Services
{
    public interface IServiceSetup
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration);

    }
}
