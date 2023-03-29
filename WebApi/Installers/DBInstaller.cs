using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Installers
{
    public class DBInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<TaskBoardContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("TaskBoardCS")));
        }
    }
}
