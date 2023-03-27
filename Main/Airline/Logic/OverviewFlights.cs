class OverviewFlights
{
    public void ShowAvailableFlights()
    {
        List<Flight> flights = new List<Flight>();

        // Array destinations om door heen te loopen en random te selecten
        Destination[] destinations = new Destination[] {
        new Destination("Germany", "Frankfurt", "FRA", 446, 3),
        new Destination("Germany", "Hamburg", "HAM", 415, 3),
        new Destination("Spain", "Madrid", "SPN", 1424, 4),
        new Destination("Spain", "Barcelona", "BCN", 1184, 2),
        new Destination("United Kingdom", "London", "LDN", 320, 5),
        new Destination("United Kingdom", "Manchester", "MAN", 804, 9),
        new Destination("Morocco", "Casablanca", "CMN", 2257, 10),
        new Destination("Morocco", "Tanger", "TNG", 1970, 3),

        };

        // Create flights met random destinations en voeg het daarna aan de lijst
        //wel opletten dat we dezelfde flights hebben natuurlijk, maar dat het wel blijft veranderen.
        int displayed = DateTime.Now.Minute; // Use the current minute of the day as the seed value
        Random random = new Random(displayed);

        // Randomly generate een boarding datum tussen 06:00-11:00 en 16:00-23:00
        // 13 vluhchten lol
        for (int i = 0; i < 18; i++)
        {
            // Randomly een destination selecten from the array
            Destination destination = destinations[random.Next(destinations.Length)];

            //Een random boarding datum tussen vandaag en 3 maanden generaten
            DateTime today = DateTime.Today;
            DateTime maxDate = today.AddMonths(3);
            TimeSpan timeSpan = maxDate - today;
            int days = timeSpan.Days;
            DateTime boardingDate = today.AddDays(random.Next(days));
            boardingDate = boardingDate.AddHours(random.Next(6, 12));
            if (boardingDate.Hour >= 16)
            {
                boardingDate = boardingDate.AddDays(1);
            }
            boardingDate = boardingDate.AddHours(random.Next(16, 24));

            int fno = random.Next(5000);

            // Create a flight with the randomly selected destination and boarding date
            Airplane airplane = new Airplane("Boeing 747", "B0747", 1, 20, 50, 150, 10);
            Airplane airplane2 = new Airplane("Boeing 878", "B0878", 1, 20, 50, 150, 10);
            Flight flight = new Flight($"FL{fno}", airplane, boardingDate, boardingDate.AddHours(destination.FlightDuration), destination);
            Flight flight2 = new Flight($"FL{fno}", airplane2, boardingDate, boardingDate.AddHours(destination.FlightDuration), destination);

            // Add the flight to the list if its boarding date is in the future and it's within the allowed time range
            if (flight.BoardingDate > DateTime.Now &&
                ((flight.BoardingDate.Hour >= 6 && flight.BoardingDate.Hour <= 11) ||
                (flight.BoardingDate.Hour >= 16 && flight.BoardingDate.Hour <= 23)))
            {
                flights.Add(flight);
                flights.Add(flight2);
            }
        }
        // Print the flight information
        PrintFlightInformation(flights);
    }

    public void PrintFlightInformation(List<Flight> flights)
    {
        //sorteren op datum en tijd
        flights = flights.OrderBy(f => f.BoardingDate).ToList();

        // Flightnumber, airline name, date and time of departure , Destination.
        Console.WriteLine($"            Flight No          operated by            Departure           Destination             Arrival  ");
        int nummer = 0;

        {
            foreach (Flight flight in flights)
            {
                Console.WriteLine($" {nummer ++,-6}|     {flight.FlightId,-10 }   |     {flight.Airplane.Name,-12}   |     {flight.BoardingDate.ToString("yyyy-MM-dd HH:mm"), -10}   |      {flight.Destination.Airport,-8}   |     {flight.EstimatedArrival.ToString("yyyy-MM-dd HH:mm"),-10}");
            }
        }
        Console.ReadLine();
    }
}
