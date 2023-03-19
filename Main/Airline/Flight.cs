class Flight
{
    public string FlightId;
    public Airplane Airplane;
    public DateTime BoardingDate;
    public DateTime EstimatedArrival;
    public string Country;
    public string Destination;

    public Flight(string flightid, Airplane airplane, DateTime boardingdate, DateTime estimatedarrival, string country, string destination)
    {
        FlightId = flightid;
        Airplane = airplane;
        BoardingDate = boardingdate;
        EstimatedArrival = estimatedarrival;
        Country = country;
        Destination = destination;
    }


    // Calculate de prijs van de stoel, is nog niet klaar.
    public double CalculateSeatPrice(double startprice)
    {
        return startprice = 0;
    }

    // Print de informatie van de vlucht. Is ook niet klaar.
    public void PrintFlightInformation()
    {
        
    }
}