using DigitalCaesar.ServerSilencer.Service.Ipmi;
using FluentAssertions;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace ServiceUnitTests.Ipmi;

public class IpmiConnectionTest
{
    public static IEnumerable<object[]> ValidIpmiConnectionSettings =>
        new List<object[]>
        {
            new object[] { new IpmiConnectionSettings() }
        };
    public static IEnumerable<object[]> ValidIpmiConnectionSettingsValue =>
        new List<object[]>
        {
            new object[] { "test", "test", "test", "-I lanplus -H test -U test -P test " }
        };
    
    [Theory]
    [MemberData(nameof(ValidIpmiConnectionSettings))]
    public void ConstructorTest(IpmiConnectionSettings settings)
    {
        IpmiConnection testObject = new(settings);
        testObject.Should().NotBeNull();
    }

    [Theory]
    [MemberData(nameof(ValidIpmiConnectionSettingsValue))]
    public void ImplicitOperatorTest(string host, string user, string password, string expectedResult)
    {
        IpmiConnectionSettings testSettings = new() { Host = host, User = user, Password = password };
        IpmiConnection testObject = new(testSettings);
        testObject.Should().NotBeNull();
        string result = testObject;
        result.Should().Be(expectedResult);
    }
}