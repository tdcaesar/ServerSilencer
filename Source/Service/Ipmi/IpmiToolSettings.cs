namespace DigitalCaesar.ServerSilencer.Service.Ipmi;

public class IpmiToolSettings
{
    private const string DefaultPath = "";
    private const Platform DefaultPlatform = Platform.Linux;
    
    public string Path { get; set; } = DefaultPath;
    public Platform Platform { get; set; } = DefaultPlatform;

}