namespace DigitalCaesar.ServerSilencer.Service.Ipmi;

public class IpmiConnectionException : Exception
{
    public IpmiConnectionException(string mode)
        : base($"Selected Mode '{mode}' not supported.")
    {
    }
}