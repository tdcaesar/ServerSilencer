namespace DigitalCaesar.ServerSilencer.Service.Ipmi;

[Serializable]
public class IpmiConnectionException : Exception
{
    public IpmiConnectionException() : base("There was a problem with the IPMI Connection.")
    {
    }
    public IpmiConnectionException(string message) : base(message)    
    {
    }
    public IpmiConnectionException(string message, Exception inner) : base(message, inner)
    {
    }

    public static IpmiConnectionException ThrowModeNotSupported(string mode)
    {
        string message = $"Selected Mode '{mode}' not supported.";
        return new IpmiConnectionException(message);
    }
}