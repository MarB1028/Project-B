class OverviewFlights
{
    public void ShowAvailableFlights()
    {
        // Define list to hold flights
        List<Flight> flights = new List<Flight>();

        // Array of destinations to select from
        Destination[] destinations = new Destination[] {
            new Destination("Germany", "Frankfurt", "(FRA)", 446, 3),
            new Destination("Germany", "Hamburg", "(HAM)", 415, 3),
            new Destination("Spain", "Madrid", "(SPN)", 1424, 4),
            new Destination("Spain", "Barcelona", "(BCN)", 1184, 2),
            new Destination("United Kingdom", "London", "(LDN)", 320, 5),
            new Destination("United Kingdom", "Manchester", "(MAN)", 804, 9),
            new Destination("Morocco", "Casablanca", "(CMN)", 2257, 10),
            new Destination("Morocco", "Tanger", "(TNG)", 1970, 3),
        };

        // Zelfde random krijgen
        int displayed = DateTime.Now.Minute;
        Random random = new Random(displayed);

        // Generate 6 random flights
        for (int i = 0; i < 6; i++)
        {
            // random destinations selecten
            Destination destination1 = destinations[random.Next(destinations.Length)];
            Destination destination2 = destinations[random.Next(destinations.Length)];

            // Generate random boarding dates between now en 3 months from now
            DateTime startDate = DateTime.Now;
            DateTime endDate = startDate.AddMonths(3);
            TimeSpan timeSpan = endDate - startDate;
            int totalDays = (int)timeSpan.TotalDays;

            DateTime boardingTime1 = new DateTime();
            DateTime boardingTime2 = new DateTime();


            while (true)
            {
                // Generate random boarding date
                DateTime boardingDate = startDate.AddDays(random.Next(totalDays)).Date;
                DateTime boardingDate2 = startDate.AddDays(random.Next(totalDays)).Date;

                // Generate random boarding time between 6-11am or 4-11pm
                int hour = random.Next(6, 12);
                if (hour == 11 && random.Next(2) == 0)
                    hour = 10; // Ensure that the last departure is at 10am!
                boardingTime1 = new DateTime(boardingDate.Year, boardingDate.Month, boardingDate.Day, hour, random.Next(0, 60), 0);

                hour = random.Next(16, 23);
                if (hour == 23 && random.Next(2) == 0)
                    hour = 22; // Ensure that the last departure is at 10pm!
                boardingTime2 = new DateTime(boardingDate2.Year, boardingDate2.Month, boardingDate2.Day, hour, random.Next(0, 60), 0);

                // If both boarding times are within the allowed hours, break out of the loop...
                if (boardingTime1.Hour >= 6 && boardingTime1.Hour <= 11 &&
                    boardingTime2.Hour >= 16 && boardingTime2.Hour <= 23)
                {
                    break;
                }
            }

            // Generate random airplane with random number of seats
            Airplane airplane = new Airplane("Boeing 747", "B0747", 1, 20, 50, 150, 10);
            Airplane airplane2 = new Airplane("Boeing 878", "B0878", 1, 20, 50, 150, 10);

            // Create flights 
            Flight flight1 = new Flight($"Flight {random.Next(5000)}", airplane, boardingTime1, boardingTime1.AddHours(destination1.FlightDuration), destination1);
            Flight flight2 = new Flight($"Flight {random.Next(5000)}", airplane2, boardingTime2, boardingTime2.AddHours(destination2.FlightDuration), destination2);

            // Add flights to the list! yay
            flights.Add(flight1);
            flights.Add(flight2);
        }

        // Print the flight information
        PrintFlightInformation(flights);
    }

    public void PrintFlightInformation(List<Flight> flights)
    {
        //sorteren op datum en tijd
        flights = flights.OrderBy(f => f.BoardingDate).ToList();

        // Flightnumber, airline name, date and time of departure , Destination, Status.
        Console.WriteLine($"                Flight No          operated by            Departure              Destination               Arrival              Status ");
        int nummer = 1;

        // de status van de vlucht bepalen (is het al vertrokken, is het vol of is het nog beschikbaar)
        bool isfull = false;
        bool departured = false;
        string status = "On schedule";
        foreach (Flight flight in flights)
        {
            if (flight.BoardingDate < DateTime.Now)
            {
                status = "Departured";
                departured = true;
            }
            else if (flight.Airplane.FirstClassSeat == 0 && flight.Airplane.PremiumSeat == 0 && flight.Airplane.EconomySeat == 0 && flight.Airplane.ExtraSpace == 0)
            {
                status = "Full";
                isfull = true;
            }
            Console.WriteLine($" {nummer++,-6}  |    {flight.FlightId,-12}    |    {flight.Airplane.Name,-12}   |     {flight.BoardingDate.ToString("yyyy-MM-dd HH:mm"),-10}   |   {flight.Destination.City,-10} {flight.Destination.Airport,-4}    |   {flight.EstimatedArrival.ToString("yyyy-MM-dd HH:mm"),-9}  |   {status,-10}   ");
        }

        Console.WriteLine("");
        Console.WriteLine("Would you like to book a flight? (Yes/No)");
        string booked = Console.ReadLine().ToUpper();
        bool x = true;
        while (x)
        {
            if (booked == "YES" || booked == "Y")
            {
                Console.WriteLine("Which flight would you like to book?");
                int selectedFlightIndex = int.Parse(Console.ReadLine()) - 1;

                if (selectedFlightIndex >= flights.Count || selectedFlightIndex < 0)
                {
                    Console.WriteLine("Invalid flight number. Please try again.");
                }
                else
                {
                    Flight selectedFlight = flights[selectedFlightIndex];
                    if (isfull == true)
                    {
                        Console.WriteLine("Sorry, the selected flight is already full.");
                    }
                    else if (departured == true)
                    {
                        Console.WriteLine("Airplane has already departured");
                    }
                    else
                    {
                        Console.WriteLine("test");
                        // Als de user het geselect heb... hier dan verder gaan en andere classes aanroepen?
                        break;
                    }
                }
            }
            else if (booked == "NO" || booked == "N")
            {
                Console.Clear();
                Menu startscreen = new Menu();
                startscreen.StartScreen();
                x = false;
            }
            else
            {
                Console.WriteLine("Please type yes or no");
                booked = Console.ReadLine().ToUpper();
            }
        }
    }
}
