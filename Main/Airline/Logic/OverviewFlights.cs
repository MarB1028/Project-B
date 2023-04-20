using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
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
        Console.WriteLine($"{"Flight No",-12} {"Operated by",-16} {"Departure",-20} {"Destination",-20} {"Arrival",-18} {"Status",-13} {"Total Seats"}");

        DataFlights dataFlights = new DataFlights();

        int nummer = 1;
        foreach (var fl in flights)
        {
            if (fl.Destination.City == endDestination)
            {
                int total_seats = (fl.Airplane.PremiumSeat * 6) + (fl.Airplane.FirstClassSeat * 6) + (fl.Airplane.EconomySeat * 6) + (fl.Airplane.ExtraSpace * 6); //de seats zijn * 6 want in het json is het de vlucht rijen
                fl.FlightNo = nummer++; //FlightNo updaten 
                Console.WriteLine($"{fl.FlightNo,-12} {fl.Airplane.Name,-15} {fl.BoardingDate.ToString("yyyy-MM-dd HH:mm"),-20} {fl.Destination.City} {fl.Destination.Abbreviation,-8} {fl.EstimatedArrival.ToString("yyyy-MM-dd HH:mm"),-21} {fl.Destination.Status,-18} {total_seats}");
            }
            dataFlights.WriteDateToJson(flights);
        }
        ChooseFlight(flights);
    }

    public void ChooseFlight(List<Flight> flights)
    {
        Console.WriteLine("Would you like to book a flight?\n1.Yes\n2.No"); // vraag of de user een vlucht wilt selectreren?
        int booked = Convert.ToInt32(Console.ReadLine());
        bool x = true;
        while (x)
        {
            DataFlights dataFlights = new DataFlights();
            if (booked == 1) // ja?
            {
                Console.WriteLine("Please choose the number of flight you would like to book."); // welke vlucht?
                int selectedFlightNo = Convert.ToInt32(Console.ReadLine());

                Flight selectedFlight = flights.FirstOrDefault(fl => fl.FlightNo == selectedFlightNo); // zoekt naar de geselecteerde vlucht

                if (selectedFlightNo == 0) // als user 0 enter, dan word je naar de main page gestuurd
                {
                    // FlightNo resetten naar 0
                    foreach (var fl in flights)
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
                        Console.WriteLine("Please choose another flight or press 0 to go back.");
                    }
                    else if (selectedFlight.Destination.Status == "Full")
                    {
                        Console.WriteLine("Selected flight is full.");
                        Console.WriteLine("Please choose another flight or press 0 to go back.");
                    }
                    else
                    {
                        Console.WriteLine("You are now being redirected to the booking page");
                        // FlightNo resetten naar 0
                        foreach (var fl in flights)
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
                    Console.WriteLine("Invalid flight number. Please try again or press 0 to go back.");
                }

            }
            else if (booked == 2) // user wilt niet flight booken
            {
                // FlightNo resetten naar 0
                foreach (var fl in flights)
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