using Newtonsoft.Json;

class MakeTicketsForFlight
{
    public Flight Flight;

    public MakeTicketsForFlight(Flight flight)
    {
        Flight = flight;
    }

    public void MakeTickets()
    {
        List<BookTicket> bookticketlist = new List<BookTicket>() { };
        
        List<string> Seatype = new List<string>()
        {
            "First-Class",
            "Premium",
            "Economy",
            "Regular"
        };
        
        List<int> AllSeats = new List<int>()
        {
            Flight.Airplane.FirstClassSeat,
            Flight.Airplane.PremiumSeat,
            Flight.Airplane.EconomySeat,
            Flight.Airplane.RegularSeat
        };

        // Je moet hier de standaard prijs doorgeven in de method Flight.CalculateSeatPrice(x).
        // De prijs wordt berekend door de te vermenigvuldigen met de multiplier van de vlucht die je meegeeft.
        int seatnumber = 0;
        for (int i = 0; i < AllSeats.Count; i++)
        {
            for (int j = 0; j < AllSeats[i]; j++)
            {
                switch (Seatype[i])
                {
                    case "First-Class":
                        seatnumber++;
                        bookticketlist.Add(new BookTicket(false, new Ticket("Empty", "Empty", null, new Seat($"{Flight.Airplane.Carrierid}-{seatnumber}", Seatype[i], Flight.CalculateSeatPrice(0)), "Empty")));
                        break;
                    case "Premium":
                        seatnumber++;
                        bookticketlist.Add(new BookTicket(false, new Ticket("Empty", "Empty", null, new Seat($"{Flight.Airplane.Carrierid}-{seatnumber}", Seatype[i], Flight.CalculateSeatPrice(0)), "Empty")));
                        break;
                    case "Economy":
                        seatnumber++;
                        bookticketlist.Add(new BookTicket(false, new Ticket("Empty", "Empty", null, new Seat($"{Flight.Airplane.Carrierid}-{seatnumber}", Seatype[i], Flight.CalculateSeatPrice(0)), "Empty")));
                        break;
                    case "Regular":
                        seatnumber++;
                        bookticketlist.Add(new BookTicket(false, new Ticket("Empty", "Empty", null, new Seat($"{Flight.Airplane.Carrierid}-{seatnumber}", Seatype[i], Flight.CalculateSeatPrice(0)), "Empty")));
                        break;
                }
            }                      
        }
        
        string json = JsonConvert.SerializeObject(bookticketlist, Formatting.Indented);
        if (!File.Exists($"{Flight.Airplane.Name}-{Flight.Destination}.json"))
        {
            File.WriteAllText($"{Flight.Airplane.Name}-ID{Flight.Airplane.AirplaneId}-{Flight.FlightId}.json", json);
        }
        else
        {
            File.WriteAllText($"{Flight.Airplane.Name}-ID{Flight.Airplane.AirplaneId}-{Flight.FlightId}.json", json);
        }
    }
}