using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using rbp.Infrastructure.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace rbp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = new ConnectionString(configuration.GetConnectionString("DefaultConnection"));
            services.AddSingleton(connectionString);
            return services;
        }
    }
}
