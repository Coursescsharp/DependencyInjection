using Module2.BeforeDI.Interfaces;
using Module2.BeforeDI.Shared;
using Serilog;

namespace Module2.BeforeDI.Factories;

public class SerilogLoggerFactory : ICustomLoggerFactory
{
    public ICustomLogger CreateLogger()
    {
        ILogger serilogLogger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();

        return new SerilogLogger(serilogLogger);
    }
}
