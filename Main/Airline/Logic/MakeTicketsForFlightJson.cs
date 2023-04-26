using Newtonsoft.Json;

static class MakeTicketsForFlightJson
{
    public static void MakeTickets(Flight flight)
    {
        List<BookTicket> bookticketlist = new List<BookTicket>() { };
        
        // Type stoelen, wordt later gebruikt voor het genereren van de json file.
        List<string> Seatype = new List<string>()
        {
            "First-Class",
            "Premium",
            "Economy",
            "ExtraSpace"
        };
        

        // Een lijst met hoeveel stoelen er zijn voor elk type.
        List<int> AllSeats = new List<int>()
        {
            flight.Airplane.FirstClassSeat * 6,
            flight.Airplane.PremiumSeat * 6,
            flight.Airplane.EconomySeat * 6,
            flight.Airplane.ExtraSpace * 6,
        };

        // Dit stukje maakt het json file aan.
        int seatnumber = 0;
        int ticketid = 0;
        for (int i = 0; i < AllSeats.Count; i++)
        {
            for (int j = 0; j < AllSeats[i]; j++)
            {   
                // Checkt welke stoelen er zijn en hoeveel er gemaakt moet worden.
                switch (Seatype[i])
                {
                    // Je moet hier de standaard prijs doorgeven in de method Flight.CalculateSeatPrice(x).
                    // De prijs wordt berekend door de te vermenigvuldigen met de multiplier van de vlucht die je meegeeft.
                    case "First-Class":
                        seatnumber++;
                        ticketid++;
                        bookticketlist.Add(new BookTicket(new Ticket(null, flight, new Seat($"{flight.Airplane.Carrierid}-{seatnumber}", Seatype[i], CalculateStartPrice.CalculateSeat("First-Class")), "Empty")));
                        break;
                    case "Premium":
                        seatnumber++;
                        ticketid++;
                        bookticketlist.Add(new BookTicket(new Ticket(null, flight, new Seat($"{flight.Airplane.Carrierid}-{seatnumber}", Seatype[i], CalculateStartPrice.CalculateSeat("Premium-Class")), "Empty")));
                        break;              
                    case "Economy":
                        seatnumber++;
                        ticketid++;
                        bookticketlist.Add(new BookTicket(new Ticket(null, flight, new Seat($"{flight.Airplane.Carrierid}-{seatnumber}", Seatype[i], CalculateStartPrice.CalculateSeat("Economy-Class")), "Empty")));
                        break;
                    case "ExtraSpace":
                        seatnumber++;
                        ticketid++;
                        bookticketlist.Add(new BookTicket(new Ticket(null, flight, new Seat($"{flight.Airplane.Carrierid}-{seatnumber}", Seatype[i], CalculateStartPrice.CalculateSeat("ExtraSpace-Class")), "Empty")));
                        break;
                }
            }                      
        }
        
        // Maakt het json file aan als er geen eentje bestaat
        string json = JsonConvert.SerializeObject(bookticketlist, Formatting.Indented);
        string pathfile = $"{GetPathFile.ReturnPathFile()}\\{flight.Airplane.Name};{flight.FlightId};{flight.Destination.City}.json";
        if (!File.Exists(pathfile))
        {
            File.WriteAllText(pathfile, json);
            BookTicket.ResetCounter();
        }
       
    }
}