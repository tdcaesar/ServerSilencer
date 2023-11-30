namespace DigitalCaesar.ServerSilencer.Service.Ipmi;

public class IpmiConnectionSettings
{
    private const string DefaultHost = "";
    private const string DefaultUser = "";
    private const string DefaultPassword = "";
    
    public string Host { get; set; } = DefaultHost;
    public string User { get; set; } = DefaultUser;
    public string Password { get; set; } = DefaultPassword;
    public IpmiMode Mode => string.IsNullOrWhiteSpace(Host) ? IpmiMode.Local : IpmiMode.Remote;
}