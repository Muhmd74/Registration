using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace Registration.Api.Setups.Factory.Configuration
{
    interface IConfigurationSetup
    {
        void SetupConfiguration(IApplicationBuilder app);

    }
}
