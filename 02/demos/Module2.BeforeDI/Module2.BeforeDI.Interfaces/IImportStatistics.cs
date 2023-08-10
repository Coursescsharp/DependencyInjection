namespace Module2.BeforeDI.Interfaces;

public interface IImportStatistics
{
    void IncrementImportCount();
    void IncrementOutputCount();
    string GetStatistics();
}
