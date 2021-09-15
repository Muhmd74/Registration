using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Registration.Api.Setups.Factory.Configuration;

namespace Registration.Api.Setups.Configurations
{
    public class InitialProjectConfigurationSetup : IConfigurationSetup
    {
        public void SetupConfiguration(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
