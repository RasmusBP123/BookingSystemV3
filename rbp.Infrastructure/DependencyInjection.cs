using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using rbp.Domain.ProductContext;
using rbp.Infrastructure.EFCore;
using rbp.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace rbp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterPeristence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddDbContext<ApplicationContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));

            services.AddScoped<IProductRepository, EFCoreRepository>();


            return services;
        }
    }
}
