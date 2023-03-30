using Application;
using Infrastructure;
using WebApi.Installers;

namespace WebAPI.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMemoryCache();
            services.AddApplication();
            services.AddInfrastructure();
            services.AddControllers(); 
            services.AddEndpointsApiExplorer(); 
        }
    }
}