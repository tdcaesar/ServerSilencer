using DigitalCaesar.ServerSilencer.Service.HexValues;
using DigitalCaesar.ServerSilencer.Service.Validation;

namespace DigitalCaesar.ServerSilencer.Service.Sensors;

public sealed record SensorId
{
    private const string cDefaultFormat = "{0:X2}h";
    private const string cSearchPattern = "^([0-9A-Fa-f]{2})h$";
    private const int cMinimum = 0;
    private const int cMaximum = 255;
    private readonly int _value;
    private int Value
    {
        get => _value;
        init
        {
            if (value is < cMinimum or > cMaximum)
                throw SensorIdException.ThrowOutOfRangeException(value, cMinimum, cMaximum);
            _value = value;
        }
    }

    private string ValueInHex => ToString(); //RequestIdValue.Create(_value).ToString(); 

    public static implicit operator int(SensorId id) => id.Value;
    public static implicit operator string(SensorId id) => id.ValueInHex;
    public static explicit operator SensorId(string id) => Create(id);
    public static explicit operator SensorId(int id) => new(id);

    private SensorId(int value)
    {
        Value = value;
    }
    
    public new static SensorId Create(string valueString)
    {
        Ensure.NotNull(valueString);
        HexValue hexValue = HexValue.FromString(valueString, cSearchPattern);
        return new(hexValue);
    }
    
    public override string ToString()
    {
        return string.Format(cDefaultFormat, Value);
    }
}