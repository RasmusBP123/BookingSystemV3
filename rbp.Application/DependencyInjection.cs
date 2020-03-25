using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using rbp.Application._Common.Mappings;
using rbp.Domain.CalendarContext.Interfaces;
using System.Reflection;

namespace rbp.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            RegisterMappings();

            return services;

        }
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(profile =>
            {
                profile.AddProfile(new DomainToViewModelProfile());
            });
        }

    }
}
