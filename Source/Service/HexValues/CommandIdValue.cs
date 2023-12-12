namespace DigitalCaesar.ServerSilencer.Service.HexValues;

public sealed record CommandIdValue : HexValue
{
    private const string cDefaultFormat = "0x{Value:X2}";
    private const string cSearchPattern = "^0x([0-9A-Fa-f]{2})$";
    private CommandIdValue(int value): base(value, cDefaultFormat)
    {
    }
    public CommandIdValue Create(int value)
    {
        return new(value);
    }
    public CommandIdValue Create(string valueString)
    {
        HexValue hexValue = HexValue.FromString(valueString, cSearchPattern);
        return new(hexValue);
    }
}