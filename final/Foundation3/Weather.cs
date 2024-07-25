public class Weather
{
    private string _forecast;
    private int _temperature;
    private int _windSpeed;
    private string _cloudState;
    private int _humidity;

    public Weather(string forecast, int temperature, int windSpeed, string cloudState, int humidity)
    {
        _forecast = forecast;
        _temperature = temperature;
        _windSpeed = windSpeed;
        _cloudState = cloudState;
        _humidity = humidity;
    }

    public string GetForecast()
    {
        return _forecast;
    }

    public int GetTemperature()
    {
        return _temperature;
    }

    public int GetWindSpeed()
    {
        return _windSpeed;
    }

    public string GetCloudState()
    {
        return _cloudState;
    }

    public int GetHumidity()
    {
        return _humidity;
    }

    // Method to provide all weather details
    public string GetAllWeatherDetails()
    {
        return $"Forecast: {_forecast} Temperature: {_temperature} degrees\nWind Speed: {_windSpeed} km/h\nCloud State: {_cloudState}\nHumidity: {_humidity}%";
    }
}