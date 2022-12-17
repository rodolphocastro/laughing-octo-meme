using Todoer.Api;

namespace Todoer.Tests;

public class UnitTest1
{
    private readonly WeatherForecast subject;

    public UnitTest1()
    {
        subject = new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Today),
            Summary = "Cloudy with a chance of meatballs",
            TemperatureC = 32
        };
    }
    
    [Fact]
    public void TemperatureFShouldBeCalculated()
    {
        var expected = subject.TemperatureC + 32 / 0.5556;

        var got = subject.TemperatureF;
        
        Assert.Equal((int)expected, got);
    }
}