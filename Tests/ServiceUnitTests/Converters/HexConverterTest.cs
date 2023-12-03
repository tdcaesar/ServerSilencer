using DigitalCaesar.ServerSilencer.Service.Converters;
using FluentAssertions;

namespace ServiceUnitTests.Converters;

public class HexConverterTest
{
    [Theory]
    [InlineData("00", 0)]
    [InlineData("0", 0)]
    [InlineData("FF", 255)]
    [InlineData("F", 15)]
    [InlineData("0FF", 255)]
    [InlineData("00", 0)]
    [InlineData("0x0", 0)]
    [InlineData("0xFF", 255)]
    [InlineData("0xF", 15)]
    [InlineData("0x0FF", 255)]
    [InlineData("0h", 0)]
    [InlineData("00h", 0)]
    [InlineData("Fh", 15)]
    [InlineData("FFh", 255)]
    public void Method_FromHex_Test(string hexValue, int expectedValue)
    {
        // Arrange

        // Act
        int actualValue = HexConverter.FromHex(hexValue);

        // Assert
        actualValue.Should().Be(expectedValue);
    }

    [Theory]
    [InlineData(0, "00")]
    [InlineData(255, "FF")]
    public void Method_ToHex_Test(int value, string expectedValue)
    {
        // Arrange

        // Act
        string actualValue = HexConverter.ToHex(value);

        // Assert
        actualValue.Should().Be(expectedValue);
    }

    [Theory]
    [InlineData(0, "00h")]
    [InlineData(255, "FFh")]
    public void Method_ToHexId_Test(int value, string expectedValue)
    {
        // Arrange

        // Act
        string actualValue = HexConverter.ToHexId(value);

        // Assert
        actualValue.Should().Be(expectedValue);
    }
    [Theory]
    [InlineData(0, "0x00")]
    [InlineData(255, "0xFF")]
    public void Method_ToHexCommand_Test(int value, string expectedValue)
    {
        // Arrange

        // Act
        string actualValue = HexConverter.ToHexCommand(value);

        // Assert
        actualValue.Should().Be(expectedValue);
    }
}