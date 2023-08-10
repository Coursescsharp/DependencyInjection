using Module2.BeforeDI.Interfaces;
using Serilog;

namespace Module2.BeforeDI.Shared;

public class SerilogLogger : ICustomLogger
{
    private readonly ILogger _logger;

    public SerilogLogger(ILogger logger)
    {
        _logger = logger;
    }

    public void LogInformation(string message)
    {
        _logger.Information(message);
    }

    public void LogWarning(string message)
    {
        _logger.Warning(message);
    }

    public void LogError(string message)
    {
        _logger.Error(message);
    }
}
