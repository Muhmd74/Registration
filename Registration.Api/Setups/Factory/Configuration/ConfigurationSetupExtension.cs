using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace Registration.Api.Setups.Factory.Configuration
{
    public static class ConfigurationSetupExtension
    {
        public static void InstallConfigureInAssembly(this IApplicationBuilder app, IApplicationBuilder applicationBuilder)
        {
            var installers = typeof(Startup).Assembly.ExportedTypes.Where(x =>
                typeof(IConfigurationSetup).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).Select(Activator.CreateInstance).Cast<IConfigurationSetup>().ToList();

            installers.ForEach(installer => installer.SetupConfiguration(app));
        }
    }
}
