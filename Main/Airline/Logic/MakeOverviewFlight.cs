using Newtonsoft.Json;

class MakeOverviewFlight
{
    public Flight Flight;

    public MakeOverviewFlight(Flight flight)
    {
        Flight = flight;
    }

    List<Flight> flights = new List<Flight>();

    public void MakeOverview()
    {
        string pathfile = $"C:\\Users\\{Environment.UserName}\\Documents\\GitHub\\Project-B\\Main\\Airline\\DataSources\\ALLFLIGHTS;EUROPE.json";

        if (File.Exists(pathfile))
        {
            string json = File.ReadAllText(pathfile);
            flights = JsonConvert.DeserializeObject<List<Flight>>(json);
        }      

        flights.Add(Flight);
        string newJson = JsonConvert.SerializeObject(flights, Formatting.Indented);
        File.WriteAllText(pathfile, newJson);
    }

    public bool CheckForDuplicate(Flight flight)
    {
        return false;
    }
}
   