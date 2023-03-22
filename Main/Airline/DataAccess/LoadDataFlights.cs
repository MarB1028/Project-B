using Newtonsoft.Json;

class LoadDataFlights
{
    public List<Flight> LoadJsonFile()
    {
        List<Flight> flights = new List<Flight>();
        string pathfile = $"C:\\Users\\{Environment.UserName}\\Documents\\GitHub\\Project-B\\Main\\Airline\\DataSources\\ALLFLIGHTS;EUROPE.json";
        string json = File.ReadAllText(pathfile);
        
        return flights = JsonConvert.DeserializeObject<List<Flight>>(json);
    }
}