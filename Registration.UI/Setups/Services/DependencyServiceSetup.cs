using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Registration.Core.Common.Files;
using Registration.Core.Interfaces.BaseInterfaces;
using Registration.Infrastructure.UnitOfWork;
using Registration.UI.Setups.Factory.Services;

namespace Registration.UI.Setups.Services
{
    public class DependencyServiceSetup  : IServiceSetup
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            //File
            services.AddScoped<FileService>();
            services.AddScoped<UploadCore>();
        }
    }
}
