using Domain.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using ProductionScheduler.Infrastructure.DAL;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ISubTaskRepository, SubTaskRepository>();
            services.AddScoped<IDayRepository, DayRepository>();
            services.AddHostedService<CalendarInitializer>();

            return services;
        }
    }
}
