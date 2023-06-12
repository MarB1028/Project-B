public interface IDestination
{
    string DisplayNo { get; set; }
    string Country { get; set; }
    string City { get; set; }
    string Abbreviation { get; set; }
    string Airport { get; set; }
    int Distancekm { get; set; }
    int FlightDuration { get; set; }
    string Status { get; set; }
}