using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Installers
{
    public class DBInstaller : IInstaller
    {
         
            public void InstallServices(IServiceCollection services, IConfiguration configuration)
            {

            // is this class needed ? 

                //services.AddDbContext<NotesContext>(options =>
                //options.UseSqlServer(configuration.GetConnectionString("NotesPractice")));  // klasa kontekstu 

           
        }
        }
    
}
