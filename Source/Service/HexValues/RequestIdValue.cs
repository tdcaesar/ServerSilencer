namespace DigitalCaesar.ServerSilencer.Service.HexValues;

public sealed record RequestIdValue : HexValue
{
    private const string cDefaultFormat = "{Value:X2}h";
    private const string cSearchPattern = "^([0-9A-Fa-f]{2})h$";
    private RequestIdValue(int value) : base(value, cDefaultFormat)
    {
    }
    public static RequestIdValue Create(int value)
    {
        return new(value);
    }
    public static RequestIdValue Create(string valueString)
    {
        HexValue hexValue = HexValue.FromString(valueString, cSearchPattern);
        return new(hexValue);
    }
}