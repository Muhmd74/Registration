using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Registration.Api.Setups.Factory.Services;
using Registration.Core.Common.Files;
using Registration.Core.Interfaces;
using Registration.Infrastructure.UnitOfWork;

namespace Registration.Api.Setups.Services
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
