namespace DigitalCaesar.ServerSilencer.Service.Ipmi;

public class IpmiConnectionSettings
{
    private const string cHost = "";
    private const string cUser = "";
    private const string cPassword = "";
    
    public string Host { get; set; } = cHost;
    public string User { get; set; } = cUser;
    public string Password { get; set; } = cPassword;
    public IpmiMode Mode => string.IsNullOrWhiteSpace(Host) ? IpmiMode.Local : IpmiMode.Remote;
}