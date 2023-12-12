using System.Text.RegularExpressions;

namespace DigitalCaesar.ServerSilencer.Service.HexValues;

public record HexValue
{
    private const string cDefaultFormat = @"{0:X}";
    private const string cDefaultPattern = "^([0-9A-Fa-f]*)$";
    private string ValueFormat { get; } = cDefaultFormat;
    private int Value { get; }

    protected HexValue(int value, string valueFormat = cDefaultFormat)
    {
        Value = value;
        ValueFormat = valueFormat;
    }
    
    public static HexValue Create(int value)
    {
        return new(value, cDefaultFormat);
    }
    public static HexValue Create(string value)
    {
        int newValue = int.Parse(value, System.Globalization.NumberStyles.HexNumber);
        return new(newValue, cDefaultFormat);
    }
    public static implicit operator int(HexValue id) => id.Value;

    public override string ToString()
    {
        return string.Format(ValueFormat, Value);
    }
    public static HexValue FromString(string valueString, string pattern = cDefaultPattern)
    {
        Regex conversionRegex = new(pattern);
        var match = conversionRegex.Match(valueString);
        if (!match.Success)
            throw new ArgumentException($"Value '{valueString}' is not in the correct format. It should be in the format '{pattern}'.");
        int value = int.Parse(match.Groups[1].ToString(), System.Globalization.NumberStyles.HexNumber);
        
        return new(value);
    }
}