class OverviewFlights
{
    public void ShowAvailableFlights()
    {
        List<Flight> flights = new List<Flight>();
        // Create the first flight
        Airplane airplane1 = new Airplane("Boeing 747", "B0747", 1, 20, 50, 150, 10);
        Destination destination1 = new Destination("Germany", "Frankfurt", "FRA", 5000, 8);
        Flight flight1 = new Flight("BOFR76", airplane1, DateTime.Parse("2023-03-24 12:00"), DateTime.Parse("2023-03-24 14:30"), destination1);
        if (flight1.BoardingDate > DateTime.Now)
        {
            flights.Add(flight1);
        }

        // Create the second flight
        Airplane airplane2 = new Airplane("Boeing 787", "XYZ789", 2, 30, 70, 200, 20);
        Destination destination2 = new Destination("Spain", "Madrid", "SPN", 8000, 12);
        Flight flight2 = new Flight("XYZ789", airplane2, DateTime.Parse("2023-03-18 09:00"), DateTime.Parse("2023-03-18 10:00"), destination2);
        if (flight2.BoardingDate > DateTime.Now)
        {
            flights.Add(flight2);
        }

        Airplane airplane3 = new Airplane("Boeing 747", "B0747", 1, 20, 50, 150, 10);
        Destination destination3 = new Destination("Spain", "Madrid", "MDR", 5000, 8);
        Flight flight3 = new Flight("BOFR76", airplane3, DateTime.Parse("2023-03-24 09:00"), DateTime.Parse("2023-03-24 12:30"), destination3);
        if (flight3.BoardingDate > DateTime.Now)
        {
            flights.Add(flight3);
        }

        PrintFlightInformation(flights);
    }

    // Print de informatie van de vlucht.
    public void PrintFlightInformation(List<Flight> flights)
    {
        // Flightnumber, airline name, date and time of departure , Destination.
        Console.WriteLine($"   Flight No         operated by           Departure            Destination         Arrival  ");
        foreach (Flight flight in flights)
        {
            Console.WriteLine($"|    {flight.FlightId}     |    {flight.Airplane.Name}    |     {flight.BoardingDate.ToString("yyyy-MM-dd HH:mm")}    |     {flight.Destination.Airport}.     |    {flight.EstimatedArrival.ToString("yyyy-MM-dd HH:mm")}  ");
        }
    }
}
