class Destination
{
    public string Country;
    public string City;
    public string Airport;
    public int Distancekm;
    public int FlightDuration;

    public Destination(string country, string city, string airport, int distancekm, int flightDuration)
    {
        Country = country;
        City = city;
        Airport = airport;
        Distancekm = distancekm;
        FlightDuration = flightDuration;
    }
}