using EasySupport.Application.Queries.GetCategoryById;
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

            //configurar fluentValidation

            //Configurar IPipelineBehavior

            return services;
        }
    }
}
