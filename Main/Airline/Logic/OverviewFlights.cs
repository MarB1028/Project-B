using ConsoleTables;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Xml.Linq;

class OverviewFlights
{
    public void ShowAvailableFlights()
    {
        List<Flight> flights = DataFlights.ReadFlightsFromJson();

        // Morgen datum
        DateTime Today = DateTime.Today;

        // voor elke vlucht een random boarding time generaten
        int displayed = DateTime.Now.Day;
        Random random = new Random(displayed);
        DateTime startDate = DateTime.Now;
        DateTime endDate = startDate.AddMonths(3);
        TimeSpan timeSpan = endDate - startDate;
        int totalDays = (int)timeSpan.TotalDays;

        // voor elke vlucht in de lijst flights
        foreach (var flight in flights)
        {
            // een ranodm dag wordt added aan de boarding en arrivaldate als de boardingdate expired is
            if (Today > flight.BoardingDate)
            {
                // Set the status to "Departed"
                flight.Destination.Status = "Departed";

                //// een ranodm dag wordt added aan de boarding en arrivaldate als de boardingdate expired is (kan nmorgen tot 3 maanden)
                DateTime newBoardingDate = DateTime.Now.AddDays(random.Next(1, 90));

                // Gebased op day of night wordt er een tijd gemaakt
                if (flight.DayOrNight == "Day")
                {
                    int hour = random.Next(6, 12);
                    if (hour == 11 && random.Next(2) == 0)
                        hour = 10; // Laatste boarding time is niet later dan 10am
                    TimeSpan boardingTime = new TimeSpan(hour, random.Next(0, 60), 0);
                    newBoardingDate = newBoardingDate.Add(boardingTime);
                }
                else
                {
                    int hour = random.Next(16, 23);
                    if (hour == 23 && random.Next(2) == 0)
                        hour = 22; // laatste boarding tijd is niet later dan 10pm
                    TimeSpan boardingTime = new TimeSpan(hour, random.Next(0, 60), 0);
                    newBoardingDate = newBoardingDate.Add(boardingTime);
                }

                // nieuwe boarding datum zetten
                flight.BoardingDate = newBoardingDate;

                // arrival date en tijd zetten
                int flightDurationHours = flight.Destination.FlightDuration;
                TimeSpan flightDuration = new TimeSpan(flightDurationHours, 0, 0);
                DateTime estimatedArrivalDateTime = flight.BoardingDate.Add(flightDuration);
                flight.EstimatedArrival = estimatedArrivalDateTime;
            }

            if (flight.TotalSeats == 0)
            {
                flight.Destination.Status = "Full";
            }
            else if (flight.BoardingDate < DateTime.Now)
            {
                flight.Destination.Status = "Departed";

            }
            else
            {
                flight.Destination.Status = "On schedule";
            }

            // flights naar 0 resetten als dat nog niet is gedaan
            //user heeft bijv midden van het display de console gesloten.
            flight.FlightNo = 0;
        }
        //naar de json schrijven 
        DataFlights.WriteDateToJson(flights);

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
            Console.WriteLine($"Unfortunately, we can't find a flight with '{endDestination}'.\nPlease try again.");
            endDestination = Console.ReadLine().ToUpper();
        }
        Console.Clear();

        // de vluchten naar:
        Console.WriteLine($"Flight Departures");
        Console.WriteLine("");
        Console.WriteLine($"{"Flight No",-12} {"Departure",-20} {"Destination",-19} {"Arrival",-20} {"Status",-12} {"Seats",-8}{"Price",-10}{"Operated by"}");
        Console.WriteLine(new string('-', 120)); //--- in between elke row ---

        //sorteren op basis van boardingdate
        var flightsToDestination = flights.Where(f => f.Destination.DisplayNo == endDestination).OrderBy(f => f.BoardingDate);

        int nummer = 1;
        foreach (var fl in flightsToDestination)
        {
            if (fl.Destination.DisplayNo == endDestination)
            {
                fl.FlightNo = nummer++; //FlightNo updaten 
                Console.Write($"{fl.FlightNo,-12} {fl.BoardingDate.ToString("yyyy-MM-dd HH:mm"),-20} {fl.Destination.City} {fl.Destination.Abbreviation,-8} {fl.EstimatedArrival.ToString("yyyy-MM-dd HH:mm"),-19} ");

                // Print the status message in red if the flight is full or departed
                if (fl.Destination.Status == "Full" || fl.Destination.Status == "Departed")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{fl.Destination.Status,-15}");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write($"{fl.Destination.Status,-15}");
                }

                Console.Write($" {fl.TotalSeats,-6}  €{fl.MinPrice},-{fl.Airplane.Name,13}");
            }
            Console.WriteLine(new string('-', 120)); // --- in between elke row --- 
            DataFlights.WriteDateToJson(flights);
        }
        PrintSortedInformation(flights, endDestination);
    }
    public void PrintSortedInformation(List<Flight> flights, string Destination) //Soufiane's code 
    {
            int sortyesnoInt;
            int sortchoiceInt;
            int sortorderInt;
            int sortorderPriceInt;
            

            Console.WriteLine("\nahahWould you like to sort?\n1.Yes\n2.No"); // ik heb hier alleen de string naar int veranderd (zo blijft het consistent)
            string sortyesno = Console.ReadLine();
            while (int.TryParse(sortyesno, out sortyesnoInt) == false && sortyesno != "1" && sortyesno != "2")
            {
                Console.WriteLine("Please enter 1 or 2.\nWould you like to sort?\n1.Yes\n2.No"); 
                sortyesno = Console.ReadLine();
            }
            if (sortyesnoInt == 1)
            {
                Console.WriteLine("Sort by:\n1. Price\n2. Date\n3. Availability");
                string sortchoice = Console.ReadLine();
                while (int.TryParse(sortchoice, out sortchoiceInt) == false && sortyesno != "1" && sortyesno != "2" && sortyesno != "3")
                {
                    Console.WriteLine("Please enter a valid input.\nSort by:\n1. Price\n2. Date\n3. Availability");
                    sortchoice = Console.ReadLine();
                }
            if (sortchoiceInt == 1) //prijs is nu overal 100
                {
                    Console.WriteLine("How would you like to sort?\n1. Ascending\n2. Descending");
                    string sortorder = Console.ReadLine();
                    while (int.TryParse(sortorder, out sortorderInt) == false && sortorder != "1" && sortorder != "2")
                    {
                        Console.WriteLine("Please enter a valid input.\nHow would you like to sort?\n1. Ascending\n2. Descending");
                        sortorder = Console.ReadLine();
                    }
                if (sortorderInt == 1)
                    {
                        flights = flights.OrderBy(f => f.MinPrice).ToList();
                    }
                    else if (sortorderInt == 2)
                    {
                        flights = flights.OrderByDescending(f => f.MinPrice).ToList();
                    }
                }
                else if (sortchoiceInt == 2)
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

                    List<Flight> sortedlist = flights.Where(flight => flight.BoardingDate >= datesort).ToList();
                    if (sortedlist.Count == 0)
                    {
                        Console.WriteLine("No flights available\n");
                    }
                    else
                    {
                        flights = sortedlist;
                    }
                }
                else if (sortchoiceInt == 3)
                {
                    Console.WriteLine("How would you like to sort?\n1. Ascending\n2. Descending");
                    string sortorderPrice = Console.ReadLine();
                    while (int.TryParse(sortorderPrice, out sortorderPriceInt) == false && sortorderPrice != "1" && sortorderPrice != "2")
                    {
                        Console.WriteLine("Invalid input. How would you like to sort?\n1. Ascending\n2. Descending");
                        sortorderPrice = Console.ReadLine();
                    }

                    if (sortorderPriceInt == 1)
                    {
                        flights = flights.OrderBy(f => f.TotalSeats).ToList();
                    }
                    else if (sortorderPriceInt == 2)
                    {
                        flights = flights.OrderByDescending(f => f.TotalSeats).ToList();
                    }
                }
            
            Console.Clear();
            // Display na het sorteren 
            Console.WriteLine("Sorted Display:");
            Console.WriteLine($"{"Flight No",-12} {"Departure",-20} {"Destination",-19} {"Arrival",-20} {"Status",-12} {"Seats",-8}{"Price",-10}{"Operated by"}");
            Console.WriteLine(new string('-', 120)); // --- in between elke row ---
            int nummer = 1;
            foreach (var fl in flights)
            {
                if (fl.Destination.DisplayNo == Destination)
                {
                    fl.FlightNo = nummer++; //FlightNo updaten 
                    Console.Write($"{fl.FlightNo,-12} {fl.BoardingDate.ToString("yyyy-MM-dd HH:mm"),-20} {fl.Destination.City} {fl.Destination.Abbreviation,-8} {fl.EstimatedArrival.ToString("yyyy-MM-dd HH:mm"),-19} ");

                    // Print the status message in red if the flight is full or departed
                    if (fl.Destination.Status == "Full" || fl.Destination.Status == "Departed")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"{fl.Destination.Status,-15}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write($"{fl.Destination.Status,-15}");
                    }

                    Console.Write($" {fl.TotalSeats,-6}  €{fl.MinPrice},-{fl.Airplane.Name,13}");
                    Console.WriteLine(new string('-', 120)); // --- in between elke row --- 
                }
                else
                {
                    Console.Write($"{fl.Destination.Status,-15}");
                }

                Console.Write($" {fl.TotalSeats,-6}  €{fl.MinPrice},-{fl.Airplane.Name,13}");
            }
            Console.WriteLine(new string('-', 120)); // --- in between elke row --- 
        }
        ChooseFlight(flights, Destination);
    }



    public void ChooseFlight(List<Flight> flights, string destination)
    {
        int bookedInt;
        int FalseLoginInt;
        int selectedFlightNoInt;
        Console.WriteLine("Would you like to book a flight?\n1.Yes\n2.No"); // vraag of de user een vlucht wilt selectreren?
        string booked = Console.ReadLine();
        while (int.TryParse(booked, out bookedInt) == false && booked != "1" && booked != "2")
            {
                Console.WriteLine("Invalid input. Would you like to book a flight?\n1.Yes\n2.No");
                booked = Console.ReadLine();
            }
        bool x = true;
        while (x)
        {
            var flToDestination = flights.Where(f => f.Destination.DisplayNo == destination).OrderBy(f => f.BoardingDate); //Original json lijst
            if (bookedInt == 1) // ja?
            {
                //Wanneer user niet is ingelogd -> message en naar main page sturen
                while (CheckLogin() == false)
                {
                    Console.WriteLine();
                    Console.WriteLine($"You are not logged in.\nPlease register or login to book a flight");
                    Console.WriteLine("Press 0 to go back");
                    string FalseLogin = Console.ReadLine();
                    while (int.TryParse(FalseLogin, out FalseLoginInt) == false && FalseLogin != "0")
                    {
                        Console.WriteLine($"You are not logged in.\nPlease register or login to book a flight");
                        Console.WriteLine("Press 0 to go back");
                        FalseLogin = Console.ReadLine();
                    }
                    if (FalseLoginInt == 0)
                    {
                        foreach (var fl in flToDestination)
                        {
                            fl.FlightNo = 0;

                        }
                        DataFlights.WriteDateToJson(flights);
                        Console.WriteLine("You are now being redirected to the main page");
                        Thread.Sleep(2500);
                        Console.Clear();
                        Menu.StartScreen();
                        x = false;
                    }
                    else // als uder toch besluit om grappig te zijn en een ander int te geven
                    {
                        Console.WriteLine("Please press 0");
                    }
                }
                Console.WriteLine("Please enter the number of flight you would like to book."); // welke vlucht?
                string selectedFlightNo = Console.ReadLine();
                while (int.TryParse(selectedFlightNo, out selectedFlightNoInt) == false)
                {
                    Console.WriteLine("Invalid input. Please enter the number of flight you would like to book.");
                    booked = Console.ReadLine();
                }


                Flight selectedFlight = flights.FirstOrDefault(fl => fl.FlightNo == selectedFlightNoInt); // zoekt naar de geselecteerde vlucht

                if (selectedFlightNoInt == 0) // als user 0 enter, dan word je naar de main page gestuurd
                {
                    // FlightNo resetten naar 0
                    foreach (var fl in flToDestination)
                    {
                        fl.FlightNo = 0;
                    }
                    DataFlights.WriteDateToJson(flights);
                    Console.Clear();
                    Menu.StartScreen();
                    x = false;

                }
                else if (selectedFlight != null) //als user een bestaand vlucht heeft gekozen
                {
                    // hier checkt het naar de flight status. if departed or full -> proper message
                    if (selectedFlight.Destination.Status == "Departed")
                    {
                        Console.WriteLine("Selected flight has already departed.");
                        Console.WriteLine("Please choose another flight or enter 0 to go back.");
                    }
                    else if (selectedFlight.Destination.Status == "Full")
                    {
                        Console.WriteLine("Selected flight is full.\n");
                        
                        //Hier print je de volgende flight uit
                        
                        while (selectedFlightNoInt < flToDestination.Count()) 
                        {
                           
                            foreach (Flight flight in flights) 
                            {
                                if (flight.FlightNo == selectedFlightNoInt+1) 
                                {
                                    if (flight.Destination.Status == "Full") 
                                    {
                                        selectedFlightNoInt++;
                                    }
                                    else 
                                    {
                                        Flight nextFlight = flights.FirstOrDefault(fl => fl.FlightNo == selectedFlightNoInt+1);
                                        Console.WriteLine("The next flight to this destination will be:");
                                        Console.WriteLine($"{"Flight No",-12} {"Departure",-20} {"Destination",-19} {"Arrival",-20} {"Status",-12} {"Seats",-8}{"Price",-10}{"Operated by"}");
                                        Console.WriteLine(new string('-', 120)); //--- in between elke row ---
                                        Console.Write($"{nextFlight.FlightNo,-12} {nextFlight.BoardingDate.ToString("yyyy-MM-dd HH:mm"),-20} {nextFlight.Destination.City} {nextFlight.Destination.Abbreviation,-8} {nextFlight.EstimatedArrival.ToString("yyyy-MM-dd HH:mm"),-19} ");
                           
                                        Console.Write($"{nextFlight.Destination.Status,-15}");

                                        Console.Write($" {nextFlight.TotalSeats,-6}  €{nextFlight.MinPrice},-{nextFlight.Airplane.Name,13}\n");

                                        //hier wordt gevraagd of je de volgende vlucht wilt boeken, 
                                        //zo niet wordt je terug gestuurd naar het begin van vlucht boeken
                                        Console.WriteLine("Do you want to book this flight instead? (Y/N)");
                                        string ans = Console.ReadLine().ToUpper();
                                        if (ans == "Y") 
                                        {
                                            Console.WriteLine("You are now being redirected to the booking page");
                                            // FlightNo resetten naar 0
                                            foreach (var fl in flToDestination)
                                            {
                                                fl.FlightNo = 0;

                                            }
                                            DataFlights.WriteDateToJson(flights);
                                            //hier de volgende stap aanroepen
                                            MakeTicketsForFlightJson.MakeTickets(nextFlight); // hier maakt het een "ticket" aan
                                            CheckSeatAvailability checkSeatAvailability = new CheckSeatAvailability(nextFlight); //volgende stap wordt aangeroepen
                                            checkSeatAvailability.AvailableSeats();

                                            x = false; 
                                        }
                                        Console.Clear();
                                        ChooseFlight(flights,destination);
                                    }
                                }
                            }
                        }
                        if (selectedFlightNoInt >= flToDestination.Count())
                            {
                                Console.WriteLine("There are no other flights available in the near future.");
                                Console.WriteLine("Please, come back soon to check for new flights.\n");
                                ChooseFlight(flights, destination);
                            }
                        else 
                        {
                            Console.WriteLine("Please choose another flight or enter 0 to go back.");
                        }      
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.Write("Press ENTER to continue...");
                        Console.ReadLine();

                        // FlightNo resetten naar 0
                        foreach (var fl in flToDestination)
                        {
                            fl.FlightNo = 0;

                        }
                        DataFlights.WriteDateToJson(flights);
                        //hier de volgende stap aanroepen
                        MakeTicketsForFlightJson.MakeTickets(selectedFlight); // hier maakt het een "ticket" aan
                        Console.Clear();
                        CheckSeatAvailability checkSeatAvailability = new CheckSeatAvailability(selectedFlight); //volgende stap wordt aangeroepen
                        checkSeatAvailability.AvailableSeats();

                        x = false;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid flight number. Please try again or enter 0 to go back.");
                }
            }
            else if (bookedInt == 2) // user wilt niet flight booken
            {
                // FlightNo resetten naar 0
                foreach (var fl in flToDestination)
                {
                    fl.FlightNo = 0;

                }
                DataFlights.WriteDateToJson(flights);
                Console.Clear();
                Menu.StartScreen();
                x = false;
            }
        }
    }


    public bool CheckExistingDestination(string EndDestination) // checkt of ingevulde destination overeenkomt met een city in het json bestand
    {
        List<Flight> flights = DataFlights.ReadFlightsFromJson();

        foreach (Flight flight in flights)
        {
            if (flight.Destination.DisplayNo == EndDestination)
            {

                return true;
            }
        }
        return false;
    }

    public bool CheckLogin() //checkt of user is ingelogd of niet
    {
        List<Account> accounts = SetGetAccounts.ReadAccountsFromJSON();

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