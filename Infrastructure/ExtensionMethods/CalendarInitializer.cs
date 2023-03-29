using Domain.Entities;
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
        public async Task StartAsync(CancellationToken cancellationToken) 
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<TaskBoardContext>();
                 
                 var allDays  =   await  dbContext.Days.ToListAsync();
                 
                var today = DateTime.Today;

                var mondayOfCurrentWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);

                for (int i = 0; i < 38; i++)
                {
                  var dayToCheck = mondayOfCurrentWeek.AddDays(i);
                     
                 bool exist = allDays.Any(x => x.GetDate() == mondayOfCurrentWeek.AddDays(i));

                    if (!exist)
                    {
                        var dayToCreate = new Day(Guid.NewGuid(), mondayOfCurrentWeek.AddDays(i), "t", "d",
                          false); 
                        dbContext.Add(dayToCreate);
                    }
                }

                dbContext.SaveChanges();
            }
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
