using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Principal;

class OverviewFlights
{
    public void FlightHeader()
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("STEP 1/5 of the booking process: Choose your flight");
        Console.WriteLine("======================================================");
        Console.ResetColor(); /* Vermelden waar we naar toe vliegen */
        Console.WriteLine("Start the search for your next journey here");
        Console.WriteLine("");    
        Console.Write("Destinations\n");
        Console.WriteLine("*Germany:\t\t- Frankfurt\t\t- Munchen");
        Console.WriteLine("*Spain:\t\t\t- Barcelona\t\t- Malaga");
        Console.WriteLine("*Greece:\t\t- Athens\t\t- Mykonos");
        Console.WriteLine("*United Kingdom:\t- London\t\t- Manchester");
        Console.WriteLine("*Croatia:\t\t- Zagreb\t\t- Zadar");
        Console.WriteLine();

        ShowAvailableFlights();
    }
    public void ShowAvailableFlights()
    {
        DataFlights dataFlights = new DataFlights();
        List<Flight> flights = dataFlights.ReadFlightsFromJson();

        // voor elke vlucht een random boarding time generaten
        int displayed = DateTime.Now.Day; //seed dat de display the same is voor vandaag
        Random random = new Random(displayed);

        // datum between nu en 3 months
        DateTime startDate = DateTime.Now;
        DateTime endDate = startDate.AddMonths(3);
        TimeSpan timeSpan = endDate - startDate;
        int totalDays = (int)timeSpan.TotalDays;

        // voor elke vlucht in de lijst flights
        foreach (Flight flight in flights)
        {
            // ranodm boarding date generaten
            DateTime boardingDate = startDate.AddDays(random.Next(totalDays)).Date;

            // random boarding datum generate
            int hour = random.Next(6, 12);
            if (hour == 11 && random.Next(2) == 0)
                hour = 10; // laatste always 10am
            TimeSpan boardingTime = new TimeSpan(hour, random.Next(0, 60), 0);

            // voor de ochtendvluchten 
            if (flight.DayOrNight == "Day")
            {

                DateTime boardingDateTime = boardingDate + boardingTime;
                flight.BoardingDate = boardingDateTime;
            }
            // anders de avond vluchten
            else
            {
                hour = random.Next(16, 23);
                if (hour == 23 && random.Next(2) == 0)
                    hour = 22; // laatste is always 10pm
                TimeSpan boardingTime2 = new TimeSpan(hour, random.Next(0, 60), 0);

                DateTime boardingDateTime2 = boardingDate + boardingTime2;
                flight.BoardingDate = boardingDateTime2;
            }

            // estimated arrival date and time calculaten
            int flightDurationHours = flight.Destination.FlightDuration;
            TimeSpan flightDuration = new TimeSpan(flightDurationHours, 0, 0);
            DateTime estimatedArrivalDateTime = flight.BoardingDate.Add(flightDuration);
            flight.EstimatedArrival = estimatedArrivalDateTime;

            int total_seats = (flight.Airplane.PremiumSeat * 6) + (flight.Airplane.FirstClassSeat * 6) + (flight.Airplane.EconomySeat * 6) + (flight.Airplane.ExtraSpace * 6);
            if (flight.BoardingDate < DateTime.Now)
            {
                flight.Destination.Status = "Departed";

            }
            else if (total_seats == 0)
            {
                flight.Destination.Status = "Full";
            }
            else
            {
                flight.Destination.Status = "On schedule";
            }
        }

        //naar de json schrijven 
        dataFlights.WriteDateToJson(flights);

        // Print flight information
        PrintFlightInformation(flights);
    }


    public void PrintFlightInformation(List<Flight> flights)
        {
        Console.WriteLine("Please enter your flight destination below");
        string endDestination = Console.ReadLine().ToUpper();
        while (CheckExistingDestination(endDestination) == false)
        {
            Console.WriteLine();
            Console.WriteLine($"We dont fly to {endDestination} yet\nPlease give another destination");
            endDestination = Console.ReadLine().ToUpper()!;

        }
        Console.Clear();
        Console.WriteLine($"Flights to destination: {endDestination}");
        Console.WriteLine("");

        // Print the flight information
        Console.WriteLine($"{"Flight No",-12} {"Operated by",-16} {"Departure",-20} {"Destination",-20} {"Arrival",-18} {"Status",-13} {"Total Seats"}");
        int nummer = 1;
        foreach (Flight flight in flights)
        {
            if (flight.Destination.City == endDestination)
            {
                int total_seats = (flight.Airplane.PremiumSeat * 6) + (flight.Airplane.FirstClassSeat * 6) + (flight.Airplane.EconomySeat * 6) + (flight.Airplane.ExtraSpace * 6);
                Console.WriteLine($"{nummer++,-12} {flight.Airplane.Name,-15} {flight.BoardingDate.ToString("yyyy-MM-dd HH:mm"),-20} {flight.Destination.City} {flight.Destination.Abbreviation,-8} {flight.EstimatedArrival.ToString("yyyy-MM-dd HH:mm"),-21} {flight.Destination.Status,-18} {total_seats}");
            }
        }
        Console.WriteLine("");
        Console.WriteLine("Would you like to book a flight?\n1.Yes\n2.No");
        int booked = Convert.ToInt32( Console.ReadLine());  
        bool x = true;
        while (x)
        {
            if (booked == 1)
            {
                Console.WriteLine("Please choose the number of flight you would like to book.");
                int selectedFlightNum = int.Parse(Console.ReadLine()) - 1 ;

                if (selectedFlightNum >= nummer || selectedFlightNum == 10)
                {
                    Console.WriteLine("Invalid flight number. Please try again.");
                }
                else if (selectedFlightNum == -1)
                {
                    Console.Clear();    
                    Menu.StartScreen();
                    x= false;
                }
                else
                { 
                    // checken of de vlucht full or departed is
                    Flight flight = flights[selectedFlightNum];
                    int totalSeats = (flight.Airplane.PremiumSeat * 6) + (flight .Airplane.FirstClassSeat * 6) + (flight.Airplane.EconomySeat * 6) + (flight.Airplane.ExtraSpace * 6);
                    if (flight.Destination.Status == "Departed")
                    {
                        Console.WriteLine("Selected flight has already departed.");
                        Console.WriteLine("Please choose another flight or press 0 to go back.");

                    }
                    else if (totalSeats == 0)
                    {
                        Console.WriteLine("Selected flight is full.");
                        Console.WriteLine("Please choose another flight or press 0 to go back.");
                    }
                   else
                    {
                        // Hier de stoelen aanroepen
                        Console.WriteLine("Booking successful!");
                    }
                }
            }
            else if (booked == 2)
            {
                Console.Clear();
                Menu.StartScreen();
                x = false;
            }
            else
            {
                Console.WriteLine("Please choose 1 or 2");
                booked = Convert.ToInt32(Console.ReadLine());
            }
        }
    }

    public bool CheckExistingDestination(string EndDestination) // checkt of ingevulde destination overeenkomt met een city in het json bestand
    {
        DataFlights dataFlights = new();
        List<Flight> flights = dataFlights.ReadFlightsFromJson();

        foreach (Flight flight in flights)
        {
            if (flight.Destination.City == EndDestination)
            {
                return true;
            }
        }
        return false;
    }
}