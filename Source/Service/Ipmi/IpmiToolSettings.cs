namespace DigitalCaesar.ServerSilencer.Service.Ipmi;

public class IpmiToolSettings
{
    private const string cPath = "";
    private const Platform cPlatform = Platform.Linux;
    
    public string Path { get; set; } = cPath;
    public Platform Platform { get; set; } = cPlatform;

}