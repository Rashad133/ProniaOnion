using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using ProniaOnion.Application.Validators;
using System.Reflection;

namespace ProniaOnion.Application.ServisRegistration
{
    public static class ServicRegistration
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            
            services.AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining(typeof(ProductCreateDtoValidator)));

            return services;
        }
    }
}
