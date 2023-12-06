namespace DigitalCaesar.ServerSilencer.Service.Converters;

public record HexValue
{
    private const string cDefaultFormat = "{Value:X}";
    private string ValueFormat { get; } = cDefaultFormat; 
    private int Value { get; }

    protected HexValue(int value, string valueFormat)
    {
        Value = value;
        ValueFormat = valueFormat;
    }
    
    public HexValue(int value)
    {
        Value = value;
        ValueFormat = cDefaultFormat;
    }
    public static implicit operator int(HexValue id) => id.Value;

    public override string ToString()
    {
        return string.Format(ValueFormat);
    }
}

public sealed record RequestIdValue : HexValue
{
    private const string cDefaultFormat = "{Value:X2}h";
    public RequestIdValue(int value) : base(value, cDefaultFormat)
    {
    }
}
public sealed record CommandIdValue : HexValue
{
    private const string cDefaultFormat = "0x{Value:X2}";
    public CommandIdValue(int value): base(value, cDefaultFormat)
    {
    }
}

public class HexConverter
{
    public static int FromHex(string value)
    {
        bool hasPrefix = value.StartsWith("0x");
        bool hasSuffix = value.EndsWith("h");
        int start = hasPrefix ? 2 : 0;
        int end = hasSuffix ? value.Length - 1 : value.Length;
        int length = end - start;
        string trimmedValueInHex = value.Substring(start, length);

        return int.Parse(trimmedValueInHex, System.Globalization.NumberStyles.HexNumber);
    }

    public static string ToHex(int value) => string.Format($"{value:X2}");
    //public static string ToHex(string value) => string.Format($"{value:X2}");
    public static string ToHexId(int value) => string.Format($"{value:X2}h");
    //public static string ToHexId(string value) => string.Format($"{value:X2}h");
    public static string ToHexCommand(int value) => string.Format($"0x{value:X2}");
    //public static string ToHexCommand(string value) => string.Format($"0x{value:X2}");
}