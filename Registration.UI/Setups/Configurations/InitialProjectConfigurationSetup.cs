using Microsoft.AspNetCore.Builder;
using Registration.UI.Setups.Factory.Configuration;

namespace Registration.UI.Setups.Configurations
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
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
