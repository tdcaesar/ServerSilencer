using DigitalCaesar.ServerSilencer.Service.HexValues;
using FluentAssertions;

namespace ServiceUnitTests.Converters;

public class HexValueTest
{
    [Theory]
    [InlineData(0)]
    [InlineData(255)]
    public void Constructor_Create_FromValidInt_Test(int testValue)
    {
        // Arrange

        // Act
        HexValue testObject = HexValue.Create(testValue);

        // Assert
        testObject.Should().NotBeNull();
    }
    
    
    [Theory]
    [InlineData("00")]
    [InlineData("0")]
    [InlineData("FF")]
    [InlineData("F")]
    [InlineData("0FF")]
    public void Constructor_Create_FromValidString_Test(string testValue)
    {
        // Arrange

        // Act
        HexValue testObject = HexValue.Create(testValue);

        // Assert
        testObject.Should().NotBeNull();
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(255)]
    public void Method_Implicit_FromIntToInt_Test(int testValue)
    {
        // Arrange
        int expectedValue = testValue;
        HexValue testObject = HexValue.Create(testValue);

        // Act
        int result = testObject;

        // Assert
        result.Should().Be(expectedValue);
    }
    [Theory]
    [InlineData("0", 0)]
    [InlineData("FF", 255)]
    public void Method_Implicit_FromStringToInt_Test(string testValue, int expectedValue)
    {
        // Arrange
        HexValue testObject = HexValue.Create(testValue);

        // Act
        int result = testObject;

        // Assert
        result.Should().Be(expectedValue);
    }
    [Theory]
    [InlineData(0, "0")]
    [InlineData(255, "FF")]
    public void Method_ToString_Test(int testValue, string expectedValue)
    {
        // Arrange
        HexValue testObject = HexValue.Create(testValue);

        // Act
        string result = testObject.ToString();

        // Assert
        result.Should().Be(expectedValue);
    }
    [Theory]
    [InlineData("0", 0)]
    [InlineData("FF",255)]
    public void Method_FromString_Default_Test(string testValue, int expectedValue)
    {
        // Arrange
        // Act
        HexValue testObject = HexValue.FromString(testValue);
        int result = testObject;

        // Assert
        result.Should().Be(expectedValue);
    }
    [Theory]
    [InlineData("0", "^([0-9A-Fa-f]*)$", 0)]
    [InlineData("FF","^([0-9A-Fa-f]*)$", 255)]
    public void Method_FromString_Test(string testValue, string testPattern, int expectedValue)
    {
        // Arrange
        // Act
        HexValue testObject = HexValue.FromString(testValue, testPattern);
        int result = testObject;

        // Assert
        result.Should().Be(expectedValue);
    }
    [Theory]
    [InlineData("0h", "^([0-9A-Fa-f])$", 0)]
    [InlineData("0xFF","^([0-9A-Fa-f])$", 255)]
    public void Method_FromString_Invalid_Test(string testValue, string testPattern, int expectedValue)
    {
        // Arrange
        HexValue Action() => HexValue.FromString(testValue, testPattern);
        
        // Act
        // Assert
        FluentActions.Invoking(Action).Should().Throw<ArgumentException>();
    }
    
}