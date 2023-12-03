using DigitalCaesar.ServerSilencer.Service.Converters;

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
                throw SensorIdException.ThrowOutOfRangeException(value, Minimum, Maximum);
            _value = value;
        }
    }

    private string ValueInHex => HexConverter.ToHexId(_value); 

    public static implicit operator int(SensorId id) => id.Value;
    public static implicit operator string(SensorId id) => id.ValueInHex;
    public static explicit operator SensorId(string id) => new(id);
    public static explicit operator SensorId(int id) => new(id);

    public SensorId(string valueInHex)
    {
        if (string.IsNullOrWhiteSpace(valueInHex))
            throw SensorIdException.ThrowNullException();
        
        Value = HexConverter.FromHex(valueInHex);
    }

    public SensorId(int value)
    {
        Value = value;
    }
}