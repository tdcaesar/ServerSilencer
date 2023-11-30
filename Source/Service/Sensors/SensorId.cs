namespace DigitalCaesar.ServerSilencer.Service.Sensors;

public class SensorId
{
    private const int Minimum = 0;
    private const int Maximum = 255;
    private readonly int _value;
    private int Value
    {
        get => _value;
        init
        {
            if (value is < Minimum or > Maximum)
                throw new SensorIdException(value);
            _value = value;
        }
    }

    private string ValueInHex => string.Format($"{_value:X2}h");

    public static implicit operator int(SensorId id) => id.Value;
    public static implicit operator string(SensorId id) => id.ValueInHex;
    public static explicit operator SensorId(string id) => new(id);
    public static explicit operator SensorId(int id) => new(id);

    public SensorId(string valueInHex)
    {
        if (string.IsNullOrWhiteSpace(valueInHex))
            throw new SensorIdException();
        
        bool hasPrefix = valueInHex.StartsWith("0x");
        bool hasSuffix = valueInHex.EndsWith("h");
        int start = hasPrefix ? 2 : 0;
        int end = hasSuffix ? valueInHex.Length - 1 : valueInHex.Length;
        int length = end - start;
        
        string trimmedValueInHex = valueInHex.Substring(start, length);
        Value = int.Parse(trimmedValueInHex, System.Globalization.NumberStyles.HexNumber);
    }

    public SensorId(int value)
    {
        Value = value;
    }
}
