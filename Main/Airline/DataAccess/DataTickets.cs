using Newtonsoft.Json;

class DataTickets
{
    public List<BookTicket> ReadTicketsFromJson(Flight flight)
    {
        string pathfile = $"C:\\Users\\{Environment.UserName}\\Documents\\GitHub\\Project-B\\Main\\Airline\\DataSources\\{flight.Airplane.Name};{flight.Destination.Country};{flight.Destination.City}.json";
        if (!File.Exists(pathfile))
        {
            return new List<BookTicket>();
        }

        string json = File.ReadAllText(pathfile);
        List<BookTicket> flights = JsonConvert.DeserializeObject<List<BookTicket>>(json);
        return flights ?? new List<BookTicket>();
    }

    public void WriteTicketToJson(BookTicket ticket)
    {

    }
}