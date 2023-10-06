using Application.Validation;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;



namespace Application
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicaionServices(this IServiceCollection services)
        {
            var assembly = typeof(ApplicationServiceCollectionExtensions).Assembly;

            services.AddMediatR(config => config.RegisterServicesFromAssembly(assembly));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(assembly);

            return services;
        }
    }
}
