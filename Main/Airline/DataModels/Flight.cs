class Flight
{
    public int FlightNo;
    public string FlightId;
    public string DayOrNight;
    public Airplane Airplane;
    public DateTime BoardingDate;
    public DateTime EstimatedArrival;
    public Destination Destination;
    public int MinPrice;


    public Flight(int flightNo, string flightid, string dayOrNight, Airplane airplane, DateTime boardingdate, DateTime estimatedarrival, Destination destination, int minPrice)
    {
        FlightNo = flightNo; 
        FlightId = flightid;
        DayOrNight = dayOrNight;
        Airplane = airplane;
        BoardingDate = boardingdate;
        EstimatedArrival = estimatedarrival;
        Destination = destination;
        MinPrice = minPrice;
    }

}