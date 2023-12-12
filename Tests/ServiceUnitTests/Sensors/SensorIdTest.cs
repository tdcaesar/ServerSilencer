using DigitalCaesar.ServerSilencer.Service.Sensors;
using FluentAssertions;

namespace ServiceUnitTests.Sensors;

public class SensorIdTest
{
    [Theory]
    [InlineData("00h")]
    [InlineData("FFh")]
    public void Constructor_Create_Int_Valid_Test(string testValue)
    {
        SensorId testObject = SensorId.Create(testValue);
    }
    [Theory]
    [InlineData("00")]
    [InlineData("0h")]
    [InlineData("Fh")]
    [InlineData("0xFF")]
    [InlineData("FFF")]
    public void Constructor_Int_Invalid_Test(string testValue)
    {
        // Arrange
        SensorId Action() => SensorId.Create(testValue);
        // Act
        // Assert
        FluentActions.Invoking(Action).Should().Throw<ArgumentException>();
    }
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void Constructor_Int_Null_Test(string? testValue)
    {
        // Arrange
        SensorId Action() => SensorId.Create(testValue);
        // Act
        // Assert
        FluentActions.Invoking(Action).Should().Throw<ArgumentNullException>()
            .Which.ParamName.Should().Be("valueString");
    }
    

    [Theory]
    [InlineData("00h","00h")]
    [InlineData("FFh","FFh")]
    public void Method_ImplicitOperator_ToString_Test(string testValue, string expectedResult)
    {
        SensorId testObject = SensorId.Create(testValue);
        string result = testObject;
        result.Should().Be(expectedResult);
    }
    [Theory]
    [InlineData("00h",0)]
    [InlineData("FFh",255)]
    public void Method_ImplicitOperator_ToInt_Test(string testValue, int expectedResult)
    {
        SensorId testObject = SensorId.Create(testValue);
        int result = testObject;
        result.Should().Be(expectedResult);
    }
    [Theory]
    [InlineData(0,0)]
    [InlineData(255,255)]
    public void Method_ExplicitOperator_Int_Test(int testValue, int expectedResult)
    {
        SensorId testObject = (SensorId)testValue;
        int result = (int)testObject;
        result.Should().Be(expectedResult);
    }
    [Theory]
    [InlineData("00h","00h")]
    [InlineData("FFh","FFh")]
    public void Method_ExplicitOperator_String_Test(string testValue, string expectedResult)
    {
        // Arrange
        // Act
        SensorId testObject = (SensorId)testValue;
        // Assert
        testObject.ToString().Should().Be(expectedResult);
    }
}