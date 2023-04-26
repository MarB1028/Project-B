using Newtonsoft.Json;

static class MakeOverviewFlightJson
{
    public static void MakeOverviewJson(Flight flight)
    {
        List<Flight> flights = new List<Flight>();
        string pathfile = $"{GetPathFile.ReturnPathFile()}\\ALLFLIGHTS;EUROPE.json";

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
   