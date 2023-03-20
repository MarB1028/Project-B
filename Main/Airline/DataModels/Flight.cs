class Flight
{
    public string FlightId;
    public Airplane Airplane;
    public DateTime BoardingDate;
    public DateTime EstimatedArrival;
    public Destination Destination;

    public Flight(string flightid, Airplane airplane, DateTime boardingdate, DateTime estimatedarrival, Destination destination)
    {
        FlightId = flightid;
        Airplane = airplane;
        BoardingDate = boardingdate;
        EstimatedArrival = estimatedarrival;
        Destination = destination;
    }
}