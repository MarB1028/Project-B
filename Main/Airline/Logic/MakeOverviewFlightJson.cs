using Newtonsoft.Json;

static class MakeOverviewFlightJson
{
    public static void MakeOverviewJson(Flight flight)
    {
        List<Flight> flights = new List<Flight>();
        string pathfile = $"C:\\Users\\{Environment.UserName}\\Documents\\GitHub\\Project-B\\Main\\Airline\\DataSources\\ALLFLIGHTS;EUROPE.json";

        if (File.Exists(pathfile))
        {
            string json = File.ReadAllText(pathfile);
            flights = JsonConvert.DeserializeObject<List<Flight>>(json);
        }

        if (!flights.Any(f => f.FlightId == flight.FlightId))
        {
            flights.Add(flight);
            string newJson = JsonConvert.SerializeObject(flights, Formatting.Indented);
            File.WriteAllText(pathfile, newJson);
        }
    }
}
   