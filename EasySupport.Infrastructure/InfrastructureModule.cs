using EasySupport.Core.Repositories;
using EasySupport.Infrastructure.Persistence;
using EasySupport.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
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
            var connectionString = configuration.GetConnectionString("EasySupportCs");
            services.AddDbContext<EasySupportDbContext>(o => o.UseSqlServer(connectionString));
            //services.AddDbContext<EasySupportDbContext>(o => o.UseInMemoryDatabase("EasySupportDb"));

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ISubcategoriesRepository, SubcategoriesRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IEnterpriseRepository, EnterpriseRepository>();
            services.AddScoped<IOriginServicesRepository, OriginServicesRepository>();
            services.AddScoped<IStatusTicketRepository, StatusTicketRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<ITicketInteractionRepository, TicketInteractionRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISolutionTicketRepository, SolutionTicketRepository>();

            return services;
        }
    }
}
