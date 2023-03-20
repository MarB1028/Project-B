class Flight
{
    public string FlightId;
    public Airplane Airplane;
    public DateTime BoardingDate;
    public DateTime EstimatedArrival;
    public string Country;
    public string Destination;
    public double Multiplier;

    public Flight(string flightid, Airplane airplane, DateTime boardingdate, DateTime estimatedarrival, string country, string destination, double multiplier)
    {
        FlightId = flightid;
        Airplane = airplane;
        BoardingDate = boardingdate;
        EstimatedArrival = estimatedarrival;
        Country = country;
        Destination = destination;
        Multiplier = multiplier;
    }


    // Calculate de prijs van de stoel, is nog niet klaar. Dit is alleen een test.
    public double CalculateSeatPrice(double startprice)
    {
        return startprice * Multiplier;
    }

    // Print de informatie van de vlucht.
    public void PrintFlightInformation()
    {
        // Moet nog ingevuld worden.
    }
}