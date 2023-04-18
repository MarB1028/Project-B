class Flight
{
    public string FlightId;
    public string DayOrNight;
    public Airplane Airplane;
    public DateTime BoardingDate;
    public DateTime EstimatedArrival;
    public Destination Destination;


    public Flight(string flightid, string dayOrNight, Airplane airplane, DateTime boardingdate, DateTime estimatedarrival, Destination destination)
    {
        FlightId = flightid;
        DayOrNight = dayOrNight;
        Airplane = airplane;
        BoardingDate = boardingdate;
        EstimatedArrival = estimatedarrival;
        Destination = destination;
    }

     

}