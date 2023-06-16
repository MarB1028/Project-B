public class Flight : FlightInformation
{
    public int FlightNo { get; set; }
    public string FlightId { get; set; }
    public bool IsDeal { get; set; }
    public bool DateSort { get; set; }

    public Flight(int flightNo, string flightid, string dayOrNight, Airplane airplane, DateTime boardingdate, DateTime estimatedarrival, Destination destination, double basePrice, int totalSeats) : base(dayOrNight, airplane, boardingdate, estimatedarrival, destination, basePrice, totalSeats)
    {
        FlightNo = flightNo;
        FlightId = flightid;
        DateSort = false;
    }
}