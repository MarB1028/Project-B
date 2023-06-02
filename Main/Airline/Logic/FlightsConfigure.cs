using ConsoleTables;
using System.Diagnostics;
using System.Xml.Linq;

public static class FlightsConfigure
{
    public static void ShowAvailableFlights()
    {
        List<Flight> flights = DataFlights.ReadFlightsFromJson();
        flights = flights.OrderBy(f => f.Destination.City).ToList();

        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine($"{"Flight No",-12} {"Departure",-20} {"Destination",-19} {"Arrival",-20} {"Status",-12} {"Seats",-8}{"Price",-10}{"Operated by"}");
        Console.WriteLine(new string('-', 120)); // --- in between elke row ---
        int nummer = 1;
        foreach (var fl in flights)
        {

            fl.FlightNo = nummer++; //FlightNo updaten 
            Console.WriteLine($"{fl.FlightNo,-12} {fl.BoardingDate.ToString("yyyy-MM-dd HH:mm"),-20} {fl.Destination.City} {fl.Destination.Abbreviation,-8} {fl.EstimatedArrival.ToString("yyyy-MM-dd HH:mm"),-19} {fl.Destination.Status,-15} {fl.TotalSeats,-6}  €{fl.MinPrice},-{fl.Airplane.Name,13}");
            Console.WriteLine(new string('-', 120)); // --- in between elke row ---
        }

        Console.WriteLine("\n1: [ADD FLIGHT]");
        Console.WriteLine("2: [REMOVE FLIGHT]");
        Console.WriteLine("3: [GO BACK]");

        string input;
        do
        {
            Console.Write(": ");
            input = Console.ReadLine();
            if (input == "1" || input == "2" || input == "3")
            {
                break;
            }
        } while (true);

        if (input == "1")
        {
            AddFlightForm();
        }

        else if (input == "2")
        {
            RemoveFlightForm();
        }

        else if (input == "3")
        {
            StartFlightConfigure();
        }
    }

    public static void AddFlightForm()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("[ADMIN: ADD FLIGHT TO SYSTEM]");
        Console.WriteLine("======================================================");
        Console.ResetColor();
        Console.WriteLine();

        string flightID;
        do
        {
            Console.Write("Flight ID: ");
            flightID = Console.ReadLine();
            if (!string.IsNullOrEmpty(flightID))
            {
                flightID = flightID.ToUpper();
                break;
            }
            else Console.WriteLine("INVALID FLIGHT ID.");

        } while (true);

        string type;
        do
        {
            Console.Write("Cycle type (Day / Night): ");
            string input = Console.ReadLine();
            if (input.ToUpper() == "DAY" || input.ToUpper() == "NIGHT")
            {
                type = input.ToUpper();
                break;
            }
            else Console.WriteLine("INVALID DAY/NIGHT CYCLE.");

        } while (true);

        Airplane airplane;
        do
        {
            Console.Write("Airplane type (1: BOEING737 || 2: BOEING787 || 3: AIRBUS330): ");
            string input = Console.ReadLine();
            if (input.ToUpper() == "1" || input.ToUpper() == "2" || input.ToUpper() == "3" && !string.IsNullOrEmpty(input))
            {
                airplane = SelectAirplane(input);
                break;
            }
            else Console.WriteLine("INVALID AIRPLANE.");

        } while (true);

        DateTime boardingdate;
        do
        {
            Console.Write("Boarding date (YYYY-MM-DD HH:MM): ");
            string input = Console.ReadLine();

            string format = "yyyy-MM-dd HH:mm";

            bool isValidDateTime = DateTime.TryParseExact(input, format, null, System.Globalization.DateTimeStyles.None, out DateTime dateTime);

            if (isValidDateTime)
            {
                boardingdate = DateTime.Parse(input);
                break;
            }
            else Console.WriteLine("INVALID DATETIME.");

        } while (true);

        DateTime arrivaldate;
        do
        {
            Console.Write("Arrival date (YYYY-MM-DD HH:MM): ");
            string input = Console.ReadLine();

            string format = "yyyy-MM-dd HH:mm";

            bool isValidDateTime = DateTime.TryParseExact(input, format, null, System.Globalization.DateTimeStyles.None, out DateTime dateTime);

            if (isValidDateTime)
            {
                arrivaldate = DateTime.Parse(input);
                break;
            }
            else Console.WriteLine("INVALID ARRIVALDATE.");

        } while (true);

        string displayNo;
        do
        {
            Console.Write("Display Number: ");
            displayNo = Console.ReadLine();
            if (!string.IsNullOrEmpty(displayNo))
            {
                break;
            }
            else Console.WriteLine("INVALID DISPLAYNO.");

        } while (true);

        string country;
        do
        {
            Console.Write("Country: ");
            country = Console.ReadLine().ToUpper();
            if (!string.IsNullOrEmpty(country))
            {
                break;
            }
            else Console.WriteLine("INVALID COUNTRY.");

        } while (true);

        string city;
        do
        {
            Console.Write("City: ");
            city = Console.ReadLine().ToUpper();
            if (!string.IsNullOrEmpty(city))
            {
                break;
            }
            else Console.WriteLine("INVALID COUNTRY.");

        } while (true);

        string abberation;
        do
        {
            Console.Write("Abbreviation (XXX): ");
            abberation = Console.ReadLine().ToUpper();
            if (!string.IsNullOrEmpty(abberation))
            {
                break;
            }
            else Console.WriteLine("INVALID ABBREVIATION.");

        } while (true);

        string airport;
        do
        {
            Console.Write("Airport: ");
            airport = Console.ReadLine().ToUpper();
            if (!string.IsNullOrEmpty(airport))
            {
                break;
            }
            else Console.WriteLine("INVALID AIRPORT.");

        } while (true);

        int distance;
        do
        {
            Console.Write("Distance (KM): ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out distance))
            {
                break;
            }
            else Console.WriteLine("INVALID DISTANCE.");

        } while (true);

        int flightDuration;
        do
        {
            Console.Write("Duration: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out flightDuration))
            {
                break;
            }
            else Console.WriteLine("INVALID DURATION.");

        } while (true);

        int minprice;
        do
        {
            Console.Write("Minimum price: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out minprice))
            {
                break;
            }
            else Console.WriteLine("INVALID PRICE.");

        } while (true);

        int totalseats = (airplane.FirstClassSeat * 6) + (airplane.PremiumSeat * 6) + (airplane.EconomySeat * 6) + (airplane.ExtraSpace * 6);

        Destination newDestination = new Destination(displayNo, country, city, abberation, airport, distance, flightDuration, "On schedule");
        Flight flight = new Flight(0, flightID, type, airplane, boardingdate, arrivaldate, newDestination, minprice, totalseats);
        Addflight(flight);
        Thread.Sleep(3000);
        StartFlightConfigure();
    }

    public static void Addflight(Flight flight)
    {
        if (DataFlights.AddFlightToJson(flight))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{flight.FlightId} SUCCESSFULLY ADDED TO THE TERMINAL...");
            Console.WriteLine("GOING BACK TO THE FLIGHT CONFIGURE...");
            Console.ResetColor();
        }

        else if (!DataFlights.AddFlightToJson(flight))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n{flight.FlightId} ALREADY IN TERMINAL.");
            Console.WriteLine("GOING BACK TO THE FLIGHT CONFIGURE...");
            Console.ResetColor();
        }
    }

    public static void RemoveFlightForm()
    {
        List<Flight> flights = DataFlights.ReadFlightsFromJson();
        flights.Sort((a, b) => string.Compare(a.Destination.Country, b.Destination.Country));

        Console.Clear();
        Console.WriteLine(" [FLIGHTS] ");
        var table = new ConsoleTable("FlightId", "Type", "Status", "Country", "City", "Airport");

        foreach (var flight in flights)
        {
            table.AddRow(flight.FlightId, flight.DayOrNight, flight.Destination.Status, flight.Destination.Country, flight.Destination.City, flight.Destination.Airport);
        }
        Console.WriteLine(table);

        string flightID;
        do
        {
            Console.Write("\nFlight ID: ");
            flightID = Console.ReadLine();
            if (!string.IsNullOrEmpty(flightID))
            {
                flightID = flightID.ToUpper();
                break;
            }
            else Console.WriteLine("INVALID FLIGHT ID.");

        } while (true);

        if (RemoveFlight(flights, flightID))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{flightID} SUCCESSFULLY REMOVED FROM TERMINAL...");
            Console.WriteLine("GOING BACK TO THE FLIGHT CONFIGURE...");
            Console.ResetColor();
        }

        else if (!RemoveFlight(flights, flightID))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n{flightID} FAILED TO REMOVE FROM TERMINAL...");
            Console.WriteLine("GOING BACK TO THE FLIGHT CONFIGURE...");
            Console.ResetColor();
        }

        Thread.Sleep(3000);
        StartFlightConfigure();
    }

    public static bool RemoveFlight(List<Flight> flights, string flightid)
    {
        if (!string.IsNullOrEmpty(flightid))
        {
            Flight flight = flights.FirstOrDefault(n => n.FlightId == flightid);
            if (flight != null)
            {
                flights.Remove(flight);
                DataFlights.WriteDateToJson(flights);
                return true;
            }
            return false;
        }

        else return false;
    }

    public static Airplane SelectAirplane(string airplane)
    {
        if (airplane == "1")
        {
            return new Airplane("BOEING737", "BO", 1, 8, 10, 12, 4);
        }

        else if (airplane == "2")
        {
            return new Airplane("BOEING787", "BO", 2, 10, 12, 14, 6);
        }

        else if (airplane == "3")
        {
            return new Airplane("AIRBUS330", "BO", 3, 10, 12, 12, 6);
        }
        return null;
    }

    public static void StartFlightConfigure()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("[ADMIN: CONFIGURE FLIGHTS]");
        Console.WriteLine("======================================================");
        Console.ResetColor();
        Console.WriteLine();

        Console.WriteLine("1: [VIEW ALL FLIGHTS]");
        Console.WriteLine("2: [GO BACK]");

        string input;
        do
        {
            Console.Write(": ");
            input = Console.ReadLine();
            if (input == "1" || input == "2")
            {
                break;
            }
        } while (true);

        if (input == "1")
        {
            Console.Clear();
            ShowAvailableFlights();
        }

        else if (input == "2")
        {
            AdminForm.StartForm();
        }
    }
}