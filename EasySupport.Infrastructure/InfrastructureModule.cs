using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EasySupport.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddRepositories()
                .AddData(configuration);

            return services;
        }

        private static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            //recuperar string de conexão com o banco de dados

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            //configurar injeção de dependencia das infertaces e seus respectivos repositórios

            return services;
        }
    }
}
