using System.Reflection;
using ExceptionTest.Interfaces;
using ExceptionTest.Middlewares;
using ExceptionTest.Orchestration;

namespace ExceptionTest.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddExceptionHandlers(this IServiceCollection services)
    {
        var handlerTypes = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => !t.IsAbstract && typeof(IExceptionHandler).IsAssignableFrom(t));

        foreach (var handlerType in handlerTypes)
        {
            services.AddTransient(typeof(IExceptionHandler), handlerType);
        }

        services.AddTransient<ExceptionHandlerOrchestrator>();

        return services;
    }

    public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}