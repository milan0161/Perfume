﻿using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Application
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicaionServices(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}
