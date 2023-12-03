namespace DigitalCaesar.ServerSilencer.Service.Ipmi;

public class IpmiConnection
{
    private const string ArgumentString = "-I lanplus -H {0} -U {1} -P {2} ";
    private string Value { get; }

    public IpmiConnection(IpmiConnectionSettings settings)
    {
        Value = settings.Mode switch
        {
            IpmiMode.Local => "",
            IpmiMode.Remote => string.Format(ArgumentString, settings.Host, settings.User, settings.Password),
            _ => throw IpmiConnectionException.ThrowModeNotSupported(settings.Mode.ToString())
        };
    }
    public static implicit operator string(IpmiConnection connection) => connection.Value;
}
