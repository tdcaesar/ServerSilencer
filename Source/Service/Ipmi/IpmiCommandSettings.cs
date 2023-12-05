namespace DigitalCaesar.ServerSilencer.Service.Ipmi;

public class IpmiCommandSettings
{
    public IpmiConnectionSettings Connection { get; set; } = new();
    public IpmiToolSettings Tool { get; set; } = new();
    public int RetryCount { get; set; } = 0;
    public int InitialDelayInSeconds { get; set; } = 5;
    public double Factor { get; set; } = 2.0;
}