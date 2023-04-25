using Newtonsoft.Json;
static class DataFlights
{
    public static string pathfile = $"C:\\Users\\{Environment.UserName}\\OneDrive\\Git\\Project B\\Project-B\\Main\\Airline\\ALLFLIGHTS;EUROPE.json";
    
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

    public static void AddFlightToJson(Flight flight)
    {
        List<Flight> flights = new List<Flight>();

        if (File.Exists(pathfile))
        {
            string json = File.ReadAllText(pathfile);
            flights = JsonConvert.DeserializeObject<List<Flight>>(json);
        }

        if (!flights.Any(f => f.FlightNo == flight.FlightNo))
        {
            flights.Add(flight);
            string newJson = JsonConvert.SerializeObject(flights, Formatting.Indented);
            File.WriteAllText(pathfile, newJson);
        }
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