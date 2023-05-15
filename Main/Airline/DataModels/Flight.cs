public class Flight
{
    public int FlightNo;
    public string FlightId;
    public string DayOrNight;
    public Airplane Airplane;
    public DateTime BoardingDate;
    public DateTime EstimatedArrival;
    public Destination Destination;
    public double BasePrice;
    public double MinPrice;
    public bool IsDeal;
    public int TotalSeats;

    public Flight(int flightNo, string flightid, string dayOrNight, Airplane airplane, DateTime boardingdate, DateTime estimatedarrival, Destination destination, double basePrice, int totalSeats)
    {
        FlightNo = flightNo;
        FlightId = flightid;
        DayOrNight = dayOrNight;
        Airplane = airplane;
        BoardingDate = boardingdate;
        EstimatedArrival = estimatedarrival;
        Destination = destination;
        BasePrice = 100;
        MinPrice = BasePrice;
        TotalSeats = totalSeats;    
    }

}