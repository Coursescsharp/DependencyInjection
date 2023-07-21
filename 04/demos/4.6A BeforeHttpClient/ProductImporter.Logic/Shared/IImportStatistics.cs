﻿namespace ProductImporter.Logic.Shared;

public interface IImportStatistics
{
    void IncrementImportCount();
    void IncrementOutputCount();

    string GetStatistics();
    void IncrementTransformationCount();
}
