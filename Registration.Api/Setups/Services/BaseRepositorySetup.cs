using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Registration.Api.Setups.Factory.Services;
using Registration.Core.Interfaces;
using Registration.Infrastructure.BaseRepository;

namespace Registration.Api.Setups.Services
{
    public class BaseRepositorySetup : IServiceSetup
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            //services.AddTransient(typeof(IBaseRepository<>),typeof(BaseRepository<>));
        }
    }
}
