using Newtonsoft.Json;
static class DataFlights
{
    private static string pathfile = $"{GetPathFile.ReturnPathFile()}\\ALLFLIGHTS;EUROPE.json";
    public static List<Flight> ReadFlightsFromJson()
    {        
        if (!File.Exists(pathfile))
        {
            return new List<Flight>();
        }

        string json = File.ReadAllText(pathfile);
        List<Flight> flights = JsonConvert.DeserializeObject<List<Flight>>(json);
        return flights ?? new List<Flight>();
    }

    public static bool AddFlightToJson(Flight flight)
    {
        List<Flight> flights = new List<Flight>();

        if (File.Exists(pathfile))
        {
            string json = File.ReadAllText(pathfile);
            flights = JsonConvert.DeserializeObject<List<Flight>>(json);
        }

        if (!flights.Any(f => f.FlightId == flight.FlightId))
        {
            flights.Add(flight);
            
            flights.Sort((a, b) => string.Compare(a.Destination.City, b.Destination.City));
            string newJson = JsonConvert.SerializeObject(flights, Formatting.Indented);
            File.WriteAllText(pathfile, newJson);
            return true;
        }
        return false;
    }
    
    public static void WriteDateToJson(List<Flight> flights)
    {
        string json = JsonConvert.SerializeObject(flights, Formatting.Indented);

        using (StreamWriter streamWriter = File.CreateText(pathfile))
        {
            streamWriter.Write(json);
        }
    }
}