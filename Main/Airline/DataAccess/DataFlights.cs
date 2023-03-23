using Newtonsoft.Json;

class DataFlights
{
    public List<Flight> ReadFlightsFromJson()
    {
        string pathfile = $"C:\\Users\\{Environment.UserName}\\Documents\\GitHub\\Project-B\\Main\\Airline\\DataSources\\ALLFLIGHTS;EUROPE.json";
        
        if (!File.Exists(pathfile))
        {
            return new List<Flight>();
        }

        string json = File.ReadAllText(pathfile);
        List<Flight> flights = JsonConvert.DeserializeObject<List<Flight>>(json);
        return flights ?? new List<Flight>();
    }

    public void WriteFlightsToJSON(Flight flight)
    {
        
    }
}