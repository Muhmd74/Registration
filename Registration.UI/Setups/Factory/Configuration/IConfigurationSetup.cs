using Microsoft.AspNetCore.Builder;

namespace Registration.UI.Setups.Factory.Configuration
{
    interface IConfigurationSetup
    {
        void SetupConfiguration(IApplicationBuilder app);

    }
}
