namespace Module2.BeforeDI.Interfaces;

public interface ICustomLogger
{
    void LogInformation(string message);
    void LogWarning(string message);
    void LogError(string message);
}
