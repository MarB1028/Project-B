using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;

class OverviewFlights
{
    public void ShowAvailableFlights()
    {
        DataFlights dataFlights = new DataFlights();
        List<Flight> flights = dataFlights.ReadFlightsFromJson();

        // vandaag datum
        DateTime startDate = DateTime.Now;

        // voor elke vlucht in de lijst flights
        foreach (var flight in flights)
        {
            if (startDate > flight.BoardingDate)
            {
                // een dag wordt added aan de boarding en arrivaldate als de boardingdate expired is
                flight.BoardingDate = flight.BoardingDate.AddDays(1);
                flight.EstimatedArrival = flight.EstimatedArrival.AddDays(1);

            }

            // totale seats en status checker 
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

        Console.OutputEncoding = System.Text.Encoding.UTF8; // weergave euro tekens
        // vlucht bestemming geven
        Console.WriteLine("Please enter your flight destination below");
        string endDestination = Console.ReadLine().ToUpper();

        //als de vlucht niet in de json bestaat -> message
        while (CheckExistingDestination(endDestination) == false)
        {
            Console.WriteLine();
            Console.WriteLine($"We dont fly to {endDestination} yet\nPlease give another destination");
            endDestination = Console.ReadLine().ToUpper();
        }
        Console.Clear();

        // de vluchten naar:
        Console.WriteLine($"Flights to destination: {endDestination}");
        Console.WriteLine("");
        Console.WriteLine($"{"Flight No",-12} {"Operated by",-16} {"Departure",-20} {"Destination",-19} {"Arrival",-20} {"Status",-10} {"Seats",-8}{"Price"}");

        DataFlights dataFlights = new DataFlights();
        var flightsToDestination = flights.Where(f => f.Destination.City == endDestination).OrderBy(f => f.BoardingDate);

        int nummer = 1;
        foreach (var fl in flightsToDestination)
        {
            if (fl.Destination.City == endDestination)
            {
                int total_seats = (fl.Airplane.PremiumSeat * 6) + (fl.Airplane.FirstClassSeat * 6) + (fl.Airplane.EconomySeat * 6) + (fl.Airplane.ExtraSpace * 6); //de seats zijn * 6 want in het json is het de vlucht rijen
                fl.FlightNo = nummer++; //FlightNo updaten 
                Console.WriteLine($"{fl.FlightNo,-12} {fl.Airplane.Name,-15} {fl.BoardingDate.ToString("yyyy-MM-dd HH:mm"),-20} {fl.Destination.City} {fl.Destination.Abbreviation,-8} {fl.EstimatedArrival.ToString("yyyy-MM-dd HH:mm"),-19} {fl.Destination.Status,-15} {total_seats,-6}  €{fl.MinPrice},-");
            }
            dataFlights.WriteDateToJson(flights);
        }
        PrintSortedInformation(flights, endDestination);
    }

    public void PrintSortedInformation(List<Flight> flights, string Destination) //Soufiane's code 
    {
        Console.WriteLine("\nWould you like to sort?\n1.Yes\n2.No"); // ik heb hier alleen de string naar int veranderd (zo blijft het consistent)
        int sortyesno = Convert.ToInt32(Console.ReadLine());
        while (sortyesno != 1 && sortyesno != 2)
        {
            Console.WriteLine("Please enter 1 or 2");
            sortyesno = Convert.ToInt32(Console.ReadLine());
        }
        if (sortyesno == 1)
        {
            Console.WriteLine("Sort by:\n1. Price\n2. Date\n3. Availability");
            string sortchoice = Console.ReadLine();
            while (sortchoice != "1" && sortchoice != "2" && sortchoice != "3")
            {
                Console.WriteLine("Please enter a valid choice");
                sortchoice = Console.ReadLine();
            }

            if (sortchoice == "1") //prijs is nu overal 100
            {
                Console.WriteLine("How would you like to sort?\n1. Ascending\n2. Descending");
                string sortorder = Console.ReadLine();
                while (sortorder != "1" && sortorder != "2")
                {
                    Console.WriteLine("Please enter a valid choice");
                    sortorder = Console.ReadLine();
                }

                if (sortorder == "1")
                {
                    flights = flights.OrderBy(f => f.MinPrice).ToList();
                }

                else if (sortorder == "2")
                {
                    flights = flights.OrderByDescending(f => f.MinPrice).ToList();
                }
            }
            else if (sortchoice == "2") 
            {
                Console.WriteLine("Enter a valid date");
                string datesortstring = Console.ReadLine();
                DateTime datesort;
                while (!DateTime.TryParseExact(datesortstring, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out datesort)) // date heb ik maar yyyy-MM-dd veranderd, zodat het als de list is.
                {
                    Console.WriteLine("Invalid date. Try again");
                    datesortstring = Console.ReadLine();
                }

                flights = flights.Select(flight =>
                {
                    if (flight.BoardingDate < datesort)
                    {
                        flight.FlightNo = 0;
                    }
                    return flight;
                }).ToList();

                List<Flight> sortedlist = flights.Where(flight => flight.BoardingDate > datesort).ToList();
                if (sortedlist.Count == 0)
                {
                    Console.WriteLine("No flights available\n");
                }
                else
                {
                    flights = sortedlist;
                }
            }
            else if (sortchoice == "3")
            {
                Console.WriteLine("How would you like to sort?\n1. Ascending\n2. Descending");
                string sortorder = Console.ReadLine();
                while (sortorder != "1" && sortorder != "2")
                {
                    Console.WriteLine("Please enter a valid choice");
                    sortorder = Console.ReadLine();
                }

                if (sortorder == "1")
                {
                    flights = flights.OrderBy(f => f.Airplane.EconomySeat + f.Airplane.ExtraSpace + f.Airplane.FirstClassSeat + f.Airplane.PremiumSeat).ToList();
                }
                else if (sortorder == "2")
                {
                    flights = flights.OrderByDescending(f => f.Airplane.EconomySeat + f.Airplane.ExtraSpace + f.Airplane.FirstClassSeat + f.Airplane.PremiumSeat).ToList();
                }
            }
            // Display na het sorteren 
            Console.WriteLine($"{"Flight No",-12} {"Operated by",-16} {"Departure",-20} {"Destination",-19} {"Arrival",-20} {"Status",-10} {"Seats",-8}{"Price"}");
            DataFlights dataFlights = new DataFlights();
            int nummer = 1;
            foreach (var fl in flights)
            {
                if (fl.Destination.City == Destination)
                {
                    int total_seats = (fl.Airplane.PremiumSeat * 6) + (fl.Airplane.FirstClassSeat * 6) + (fl.Airplane.EconomySeat * 6) + (fl.Airplane.ExtraSpace * 6); 
                    fl.FlightNo = nummer++; //FlightNo updaten 
                    Console.WriteLine($"{fl.FlightNo,-12} {fl.Airplane.Name,-15} {fl.BoardingDate.ToString("yyyy-MM-dd HH:mm"),-20} {fl.Destination.City} {fl.Destination.Abbreviation,-8} {fl.EstimatedArrival.ToString("yyyy-MM-dd HH:mm"),-19} {fl.Destination.Status,-15} {total_seats,-6}  €{fl.MinPrice},-");
                }
            }
            ChooseFlight(flights, Destination);
            
        }
        ChooseFlight(flights, Destination);
    }
        

        public void ChooseFlight(List<Flight> flights, string destination)
        {
            
            Console.WriteLine("Would you like to book a flight?\n1.Yes\n2.No"); // vraag of de user een vlucht wilt selectreren?
            int booked = Convert.ToInt32(Console.ReadLine());
            bool x = true;
            while (x)
            {
                DataFlights dataFlights = new DataFlights();
                var flToDestination = flights.Where(f => f.Destination.City == destination).OrderBy(f => f.BoardingDate); //Original json lijst
            if (booked == 1) // ja?
                {
                    while (CheckLogin() == false)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"You are not logged in.\nPlease register or login to book a flight");
                        Console.WriteLine("Press 0 to go back");
                        int FalseLogin = Convert.ToInt32(Console.ReadLine());
                        if (FalseLogin == 0)
                        {
                            foreach (var fl in flToDestination)
                            {
                                fl.FlightNo = 0;

                            }
                            dataFlights.WriteDateToJson(flights);
                            Console.WriteLine("You are now being redirected to the main page");
                            Thread.Sleep(2500);
                            Console.Clear();
                            Menu.StartScreen();
                            x = false;
                        }
                        else
                        {
                            Console.WriteLine("Please press 0");
                        }
                    x = false;
                    }
                    Console.WriteLine("Please enter the number of flight you would like to book."); // welke vlucht?
                    int selectedFlightNo = Convert.ToInt32(Console.ReadLine());

                    Flight selectedFlight = flights.FirstOrDefault(fl => fl.FlightNo == selectedFlightNo); // zoekt naar de geselecteerde vlucht

                    if (selectedFlightNo == 0) // als user 0 enter, dan word je naar de main page gestuurd
                    {
                        // FlightNo resetten naar 0
                        foreach (var fl in flToDestination)
                        {

                            fl.FlightNo = 0;

                        }
                        dataFlights.WriteDateToJson(flights);
                        Console.Clear();
                        Menu.StartScreen();
                        x = false;

                    }
                    else if (selectedFlight != null)
                    {
                        // hier checkt het naar de flight status. if departed or full -> proper message
                        if (selectedFlight.Destination.Status == "Departed")
                        {
                            Console.WriteLine("Selected flight has already departed.");
                            Console.WriteLine("Please choose another flight or enter 0 to go back.");
                        }
                        else if (selectedFlight.Destination.Status == "Full")
                        {
                            Console.WriteLine("Selected flight is full.");
                            Console.WriteLine("Please choose another flight or enter 0 to go back.");
                        }
                        else
                        {
                            Console.WriteLine("You are now being redirected to the booking page");
                        // FlightNo resetten naar 0
                        foreach (var fl in flToDestination)
                        {
                                fl.FlightNo = 0;

                            }
                            dataFlights.WriteDateToJson(flights);
                            //hier de volgende stap aanroepen
                            x = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid flight number. Please try again or enter 0 to go back.");
                    }

                }
                else if (booked == 2) // user wilt niet flight booken
                {

                // FlightNo resetten naar 0
                foreach (var fl in flToDestination)
                {
                        fl.FlightNo = 0;

                 }
                    dataFlights.WriteDateToJson(flights);
                    Console.Clear();
                    Menu.StartScreen();
                    x = false;
                }
                else // als user een ander getal toets
                {
                    Console.WriteLine("Please enter 1 or 2");
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

    public bool CheckLogin() // checkt of login is true in het json bestand.
    {
        SetGetAccounts setGetAccounts = new();
        List<Account> accounts = setGetAccounts.ReadAccountsFromJSON();

        foreach (Account account in accounts)
        {
            if (account.LoggedIn == true)
            {
                return true;
            }
        }
        return false;
    }
}