using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Registration.Api.Setups.Factory.Services
{
    public interface IServiceSetup
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration);

    }
}
