using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using rbp.Domain.ProductContext;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace rbp.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;

        }
    }
}
