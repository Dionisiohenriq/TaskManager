using Microsoft.Extensions.DependencyInjection;
using TaskManager.Application.Services;
using TaskManager.Application.Services.Interfaces;
using TaskManager.Domain.Interfaces;
using TaskManager.Infra.Repository;

namespace TaskManager.Infra.IoC;

public static class RegisterServicesExtension
{
    public static void RegisterServices(this IServiceCollection services)
    {
        // Services
        services.AddScoped<IPersonService, PersonService>();
        services.AddScoped<IPersonTaskService, PersonTaskService>();

        // Repos
        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddScoped<IPersonTaskRepository, PersonTaskRepository>();
    }
}