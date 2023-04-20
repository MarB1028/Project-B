using Newtonsoft.Json;
static class DataFlights
{
    public static List<Flight> ReadFlightsFromJson()
    {
        string pathfile = $"C:\\Users\\{Environment.UserName}\\OneDrive - Hogeschool Rotterdam\\Semester 2\\Project B\\Project-B\\Main\\Airline\\DataSources\\ALLFLIGHTS;EUROPE.json";
        
        if (!File.Exists(pathfile))
        {
            return new List<Flight>();
        }

        string json = File.ReadAllText(pathfile);
        List<Flight> flights = JsonConvert.DeserializeObject<List<Flight>>(json);
        return flights ?? new List<Flight>();
    }
}