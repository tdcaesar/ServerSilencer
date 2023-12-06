using DigitalCaesar.ServerSilencer.Service.Converters;
using DigitalCaesar.ServerSilencer.Service.Validation;

namespace DigitalCaesar.ServerSilencer.Service.Sensors;

public class SensorId
{
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

    private string ValueInHex => HexConverter.ToHexId(_value); 

    public static implicit operator int(SensorId id) => id.Value;
    public static implicit operator string(SensorId id) => id.ValueInHex;
    public static explicit operator SensorId(string id) => new(id);
    public static explicit operator SensorId(int id) => new(id);

    public SensorId(string? valueInHex)
    {
        Ensure.NotNull(valueInHex);
        Value = HexConverter.FromHex(valueInHex);
    }

    public SensorId(int value)
    {
        Value = value;
    }
}