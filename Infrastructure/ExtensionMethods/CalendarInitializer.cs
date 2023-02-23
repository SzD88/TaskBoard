using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
 

namespace ProductionScheduler.Infrastructure.DAL
{
    internal sealed class CalendarInitializer : IHostedService  
    {
        private readonly IServiceProvider _serviceProvider;
        public CalendarInitializer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task StartAsync(CancellationToken cancellationToken) // on app start
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<TaskBoardContext>();
                //  dbContext.Database.Migrate();

                //  dbContext.AddRange(machinesToReserve);
                //  dbContext.SaveChanges();
                // pobierz 30 next recordow
                 var allDays  =   await  dbContext.Days.ToListAsync();
                 
                var today = DateTime.Today;

                for (int i = 0; i < 31; i++)
                {
                  var dayToCheck = today.AddDays(i);

                    // leć po dacie od dzisiaj i probuj dodać
                 //    allDays.FirstOrDefault(x=> x.)
                    //dodaj dzien

                    //ale jezeli go jeszcze nie ma


                    // wez dzisiejszy dzien - sprawdz cyz jest

                    // jak nie ma to dodaj

                    //wez dzien +1 jak nie ma to dodaj i tak 30 razy proste
                }
            }
           // return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;

        }
        
    }
}
