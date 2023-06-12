public class Destination : IDestination
{
    public string DisplayNo { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Abbreviation { get; set; }
    public string Airport { get; set; }
    public int Distancekm { get; set; }
    public int FlightDuration { get; set; }
    public string Status { get; set; }

    public Destination(string displayNo, string country, string city, string abbreviation, string airport, int distancekm, int flightDuration, string status)
    {
        DisplayNo = displayNo;
        Country = country;
        City = city;
        Abbreviation = abbreviation;
        Airport = airport;
        Distancekm = distancekm;
        FlightDuration = flightDuration;
        Status = status;
    }
}