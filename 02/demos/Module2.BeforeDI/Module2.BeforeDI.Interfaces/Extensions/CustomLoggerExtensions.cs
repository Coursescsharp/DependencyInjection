using Microsoft.Extensions.DependencyInjection;

namespace Module2.BeforeDI.Interfaces.Extensions;

public static class CustomLoggerExtensions
{
    public static void AddCustomLogger(this IServiceCollection services, ICustomLoggerFactory loggerFactory)
    {
        // Register your library services
        // ...

        // Use the factory to create the logger
        services.AddSingleton<ICustomLogger>(provider => loggerFactory.CreateLogger());
    }
}
