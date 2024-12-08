using EasySupport.Application.Commands.InsertDepartment;
using EasySupport.Application.Queries.GetCategoryById;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace EasySupport.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddHandlers()
                .AddValidation();

            return services;
        }

        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            config.RegisterServicesFromAssemblyContaining<GetCategoryByIdQuery>());

            return services;
        }

        public static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining<InsertDepartmentCommand>();

            //Configurar IPipelineBehavior

            return services;
        }
    }
}
