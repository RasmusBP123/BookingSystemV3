using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using rbp.Domain.Abstractions;
using rbp.Domain.CalendarContext.Interfaces;
using rbp.Persistence.EFCore;
using System.Reflection;

namespace rbp.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterPeristence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddDbContext<CalendarContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(CalendarContext).Assembly.FullName)).UseLazyLoadingProxies());

            services.AddScoped<ICalendarRepository, CalendarRepository>();
            services.AddScoped<ICalendarContext, CalendarContext>();

            return services;
        }
    }
}
