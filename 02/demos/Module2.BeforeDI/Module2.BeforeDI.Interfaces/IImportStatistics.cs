namespace Module2.BeforeDI.Interfaces;

public interface IImportStatistics
{
    void IncrementImportCount();
    void IncrementTransformationCount();
    void IncrementOutputCount();
    string GetStatistics();
}
