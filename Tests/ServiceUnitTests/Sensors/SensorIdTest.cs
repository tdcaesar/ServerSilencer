using DigitalCaesar.ServerSilencer.Service.Sensors;
using FluentAssertions;

namespace ServiceUnitTests.Sensors;

public class SensorIdTest
{
    [Theory]
    [InlineData(0)]
    [InlineData(255)]
    public void ConstructorIntTest(int testValue)
    {
        SensorId testObject = new(testValue);
    }
    [Theory]
    [InlineData(-10)]
    [InlineData(300)]
    public void ConstructorIntInvalidTest(int testValue)
    {
        var exception = Assert.Throws<SensorIdException>(() => new SensorId(testValue));
    }
    
    [Theory]
    [InlineData("00")]
    [InlineData("00h")]
    [InlineData("0x00")]
    [InlineData("FF")]
    [InlineData("FFh")]
    [InlineData("0xFF")]
    public void ConstructorStringTest(string testValue)
    {
        SensorId testObject = new(testValue);
    }

    [Theory]
    [InlineData(0,"00h")]
    [InlineData(255,"FFh")]
    public void ImplicitOperatorTest(int testValue, string expectedResult)
    {
        SensorId testObject = new(testValue);
        string result = testObject;
        result.Should().Be(expectedResult);
    }
    [Theory]
    [InlineData(0,0)]
    [InlineData(255,255)]
    public void ExplicitOperatorIntTest(int testValue, int expectedResult)
    {
        SensorId testObject = (SensorId)testValue;
        int result = testObject;
        result.Should().Be(expectedResult);
    }
    [Theory]
    [InlineData("00","00h")]
    [InlineData("FF","FFh")]
    public void ExplicitOperatorStringTest(string testValue, string expectedResult)
    {
        SensorId testObject = (SensorId)testValue;
        string result = testObject;
        result.Should().Be(expectedResult);
    }
}