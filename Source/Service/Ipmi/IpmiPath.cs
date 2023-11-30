using System.Diagnostics;

namespace DigitalCaesar.ServerSilencer.Service.Ipmi;

public class IpmiPath
{
    private const string DefaultLinuxPath = "/usr/bin/ipmitool";
    private const string DefaultWindowsPath = @"C:\Program Files (x86)\Dell\SysMgt\bmc\ipmitool.exe";
    private string Value { get; }

    public IpmiPath(IpmiToolSettings settings)
    {
        Value = string.IsNullOrWhiteSpace(settings.Path)
            ? settings.Platform switch
            {
                Platform.Linux => DefaultLinuxPath,
                Platform.Windows => DefaultWindowsPath,
                _ => throw new PlatformNotSupportedException(
                    $"The platform {settings.Platform} is not supported.  Only Windows and Linux are supported.")
            }
            : settings.Path;
    }
    
    public static implicit operator string(IpmiPath path) => path.Value;
    public static implicit operator IpmiPath(IpmiToolSettings settings) => new(settings);
}