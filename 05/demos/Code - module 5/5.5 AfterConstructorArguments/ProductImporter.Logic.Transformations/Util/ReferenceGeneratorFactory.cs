using Microsoft.Extensions.DependencyInjection;

namespace ProductImporter.Logic.Transformation.Util;

public class ReferenceGeneratorFactory : IReferenceGeneratorFactory
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IIncrementingCounter _incrementingCounter;

    public ReferenceGeneratorFactory(IDateTimeProvider dateTimeProvider, IIncrementingCounter incrementingCounter)
    {
        _dateTimeProvider = dateTimeProvider;
        _incrementingCounter = incrementingCounter;
    }

    public IReferenceGenerator CreateReferenceGenerator(string prefix)
    {
        return new ReferenceGenerator(_dateTimeProvider, _incrementingCounter, prefix);
    }
}