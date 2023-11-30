using DigitalCaesar.ServerSilencer.Service.Ipmi;
using FluentAssertions;

namespace ServiceUnitTests.Ipmi;

public class IpmiCommandHandlerTest
{
    public static IEnumerable<object[]> ValidIpmiCommandSettings =>
        new List<object[]>
        {
            new object[] { new IpmiCommandSettings() }
        };
    
    [Theory]
    [MemberData(nameof(ValidIpmiCommandSettings))]
    public void ConstructorTest(IpmiCommandSettings settings)
    {
        IpmiCommandHandler testObject = new(settings);
        testObject.Should().NotBeNull();
    }
}