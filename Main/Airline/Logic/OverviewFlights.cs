class OverviewFlights
{
    public void ShowAvailableFlights()
    {
        List<Flight> flights = new List<Flight>();

        // Array destinations om door heen te loopen en random te selecten
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

        // Create flights met random destinations en voeg het daarna aan de lijst
        // Wel opletten dat we dezelfde flights hebben natuurlijk, maar dat het wel blijft veranderen. 
        int displayed = DateTime.Now.Minute; // De huidige tijd gebruiken, zodat de display wel hetzelfde blijft als we het runnen
        Random random = new Random(displayed); 

        // Randomly generate een boarding datum tussen 06:00-11:00 en 16:00-23:00
        // 12 vluhchten lol
        for (int i = 0; i < 6; i++)
        {
            Random rndm = new Random();
            //Random destination selecten van de array
            Destination destination = destinations[random.Next(destinations.Length)];

            //Random boarding date generaten tussen nu en 3 maanden in de toekomst
            DateTime startDate = DateTime.Now;
            DateTime endDate = startDate.AddMonths(3);
            TimeSpan timeSpan = endDate - startDate;
            int totalDays = (int)timeSpan.TotalDays;
            DateTime boardingDate = startDate.AddDays(random.Next(totalDays)).Date;
            DateTime boardingDate2=startDate.AddDays(random.Next(totalDays)).Date;

            // Random boarding time generaten tussen 6-11am of 16-23pm
            DateTime boardingTime;
            if (random.Next(2) == 0)
            {
                boardingTime = new DateTime(boardingDate.Year, boardingDate.Month, boardingDate.Day, rndm.Next(7, 10), rndm.Next(2, 58), 0);
            }
            else
            {
                boardingTime = new DateTime(boardingDate2.Year, boardingDate2.Month, boardingDate2.Day, rndm.Next(17, 21), rndm.Next(2, 58), 0);
            }
            // Randomly een destination selecten from the array
            Destination destination1 = destinations[random.Next(destinations.Length)];
            Destination destination2 = destinations[random.Next(destinations.Length)];

            // Vlucht maken met randomly selected destination en boarding dates
            Airplane airplane = new Airplane("Boeing 747", "B0747", 1, 20, 50, 150, 10);
            Airplane airplane2 = new Airplane("Boeing 878", "B0878", 1, 20, 50, 150, 10);
            Flight flight = new Flight($"FL{random.Next(5000)}", airplane, boardingDate, boardingTime.AddHours(destination.FlightDuration), destination1);
            Flight flight2 = new Flight($"FL{random.Next(5000)}", airplane2, boardingTime, boardingTime.AddHours(destination.FlightDuration), destination2);

            // De vluchten toevoegen aan de lijst
            flights.Add(flight);
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
        Console.WriteLine($"            Flight No          operated by            Departure              Destination               Arrival         Status ");
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
            else if (flight.Airplane.FirstClassSeat == 0 && flight.Airplane.PremiumSeat == 0  && flight.Airplane.EconomySeat == 0 && flight.Airplane.ExtraSpace == 0 )
            {
                status = "Full";
                isfull= true;
            }
                Console.WriteLine($" {nummer++,-6}|     {flight.FlightId,-10}   |     {flight.Airplane.Name,-9}   |     {flight.BoardingDate.ToString("yyyy-MM-dd HH:mm"),-9}   |   {flight.Destination.City,-10} {flight.Destination.Airport,-9}   |  {flight.EstimatedArrival.ToString("yyyy-MM-dd HH:mm"),-9}| {status,-10}");
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
                booked = Console.ReadLine();
            }
        }
    }
}