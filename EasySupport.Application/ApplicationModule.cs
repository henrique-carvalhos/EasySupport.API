using EasySupport.Application.Commands.InsertDepartment;
using EasySupport.Application.Commands.InsertSubcategories;
using EasySupport.Application.Commands.InsertUser;
using EasySupport.Application.Models;
using EasySupport.Application.Queries.GetCategoryById;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
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

            services.AddTransient<IPipelineBehavior<InsertSubcategoriesCommand, ResultViewModel<int>>, ValidateInsertSubcategoryCommandBehavior>();
            services.AddTransient<IPipelineBehavior<InsertUserCommand, ResultViewModel<int>>, ValidateInsertUserCommandBehavior>();

            return services;
        }
    }
}
