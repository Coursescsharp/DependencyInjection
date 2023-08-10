using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Module2.BeforeDI;
using Module2.BeforeDI.Factories;
using Module2.BeforeDI.Interfaces;
using Module2.BeforeDI.Interfaces.Extensions;
using Module2.BeforeDI.Interfaces.Implementations;
using Module2.BeforeDI.Shared;
using Module2.BeforeDI.Source;
using Module2.BeforeDI.Target;
using Serilog;

// Configuring the default builder for the application host and configure DI
// context: It's the host builder context (not used, but is mandatory)
// services: It's the collection that will be used to register types in 
//           the classes we want to be using and add our registrations.


using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        ICustomLoggerFactory loggerFactory = new SerilogLoggerFactory();
        services.AddCustomLogger(loggerFactory);

        services.AddResolvers();
        services.AddTransient<ProductImporter>();
        services.AddTransient<Configuration>();
        
        services.AddTransient<IPriceParser, PriceParser>();
        services.AddTransient<IProductFormatter, ProductFormatter>();
        services.AddTransient<IProductSource, ProductSource>();
        services.AddTransient<IProductTarget, ProductTarget>();
    })
    .ConfigureLogging((hostContext, logging) =>
    {
        var serilogConfig = hostContext.Configuration.GetSection("Serilog");

        Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(serilogConfig)
                .CreateLogger();

        logging.ClearProviders();
        logging.AddSerilog();
    })
    .Build();


var productImporter = host.Services.GetRequiredService<ProductImporter>();
productImporter.Run();


