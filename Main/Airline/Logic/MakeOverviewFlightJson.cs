using Newtonsoft.Json;

class MakeOverviewFlightJson
{
    public Flight Flight;

    public MakeOverviewFlightJson(Flight flight)
    {
        Flight = flight;
    }

    public void MakeOverviewJson()
    {
        List<Flight> flights = new List<Flight>();
        string pathfile = $"C:\\Users\\{Environment.UserName}\\Documents\\GitHub\\Project-B\\Main\\Airline\\DataSources\\ALLFLIGHTS;EUROPE.json";

        if (File.Exists(pathfile))
        {
            string json = File.ReadAllText(pathfile);
            flights = JsonConvert.DeserializeObject<List<Flight>>(json);
        }

        if (!flights.Any(f => f.FlightId == Flight.FlightId))
        {
            flights.Add(Flight);
            string newJson = JsonConvert.SerializeObject(flights, Formatting.Indented);
            File.WriteAllText(pathfile, newJson);
        }
    }
}
   