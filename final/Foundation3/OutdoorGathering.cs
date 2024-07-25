public class OutdoorGathering : Event
{
    private Weather _weatherForecast;

    public OutdoorGathering(string title, string description, string date, string time, Address address, Weather weatherForecast)
        : base(title, description, date, time, address)
    {
        _weatherForecast = weatherForecast;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nEvent Type: Outdoor Gathering\nWeather Forecast: {_weatherForecast.GetAllWeatherDetails()}";
    }
}