using Module2.BeforeDI.Model;

namespace Module2.BeforeDI.Source;

/// <summary>
/// This interface is used to parse
/// the currency and amount out of a price.
/// </summary>
public interface IPriceParser
{
    Money Parse(string price);
}
