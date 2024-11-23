using Assessment.Application.Contracts.Factories;
using Assessment.Application.Contracts.Repos;
using Assessment.Application.Contracts.Strategies;
using Assessment.Persistence.Implementation.Factories;
using Assessment.Persistence.Implementation.Repos;
using Assessment.Persistence.Implementation.Strategies.AddEmployee;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Assessment.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration _config)
        {
            services.AddDbContext<AssessmentDbContext>(options =>
                options.UseNpgsql(_config.GetConnectionString("Default"),
                    opt => opt.MigrationsAssembly(typeof(AssessmentDbContext).Assembly.FullName)));

            services.AddRepositories();

            services.AddFactories();

            services.AddStrategies();

            return services;
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepo, EmployeeRepo>();
        }

        private static void AddFactories(this IServiceCollection services)
        {
            services.AddScoped<IStrategyFactory, StrategyFactory>();
        }

        private static void AddStrategies(this IServiceCollection services)
        {
            services.AddTransient<IGetEmployeeDescriptionStrategy, GetEmployeeUnassignedDescriptionStrategy>();
            services.AddTransient<IGetEmployeeDescriptionStrategy, GetEmployeeOperationsDescriptionStrategy>();
            services.AddTransient<IGetEmployeeDescriptionStrategy, GetEmployeeTechDescriptionStrategy>();

            services.AddTransient<GetEmployeeUnassignedDescriptionStrategy>();
            services.AddTransient<GetEmployeeOperationsDescriptionStrategy>();
            services.AddTransient<GetEmployeeTechDescriptionStrategy>();
        }
    }
}
