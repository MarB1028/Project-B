using Newtonsoft.Json;
static class DataTickets
{
    public static List<BookTicket> ReadTicketsFromJson(Flight flight)
    {
        string pathfile = $"C:\\Users\\{Environment.UserName}\\source\\repos\\GitHub\\Project-B\\Main\\Airline\\DataSources\\{flight.Airplane.Name};{flight.Destination.Country};{flight.Destination.City}.json";

        //string pathfile = $"C:\\Users\\{Environment.UserName}\\Documents\\GitHub\\Project-B\\Main\\Airline\\DataSources\\{flight.Airplane.Name};{flight.Destination.Country};{flight.Destination.City}.json";
        if (!File.Exists(pathfile))
        {
            return new List<BookTicket>();
        }

        string json = File.ReadAllText(pathfile);
        List<BookTicket> DataFlightTickets = JsonConvert.DeserializeObject<List<BookTicket>>(json);
        return DataFlightTickets ?? new List<BookTicket>();
    }

    public static void WriteTicketToJson(Flight flight, BookTicket ticket)
    {
        List<BookTicket> DataFlightTickets = ReadTicketsFromJson(flight);

        foreach (BookTicket book in DataFlightTickets)
        {
            if (book.Ticket.Seat.SeatNumber == ticket.Ticket.Seat.SeatNumber)
            {
                book.Booked = true;
                book.Ticket = ticket.Ticket;
            }
        }
        string UpdateJSON = JsonConvert.SerializeObject(DataFlightTickets, Formatting.Indented);
        string pathfile = $"C:\\Users\\{Environment.UserName}\\OneDrive - Hogeschool Rotterdam\\Semester 2\\Project B\\Project-B\\Main\\Airline\\DataSources\\{flight.Airplane.Name};{flight.Destination.Country};{flight.Destination.City}.json";
        File.WriteAllText(pathfile, UpdateJSON);
    }
}
