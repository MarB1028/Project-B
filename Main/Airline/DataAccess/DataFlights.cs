using Newtonsoft.Json;
class DataFlights
{
    string pathfile = $"C:\\Users\\{Environment.UserName}\\source\\repos\\GitHub\\Project-B\\Main\\Airline\\DataSources\\ALLFLIGHTS;EUROPE.json";
    public List<Flight> ReadFlightsFromJson()
    {   
        if (!File.Exists(pathfile))
        {
            return new List<Flight>();
        }
        string json = File.ReadAllText(pathfile);
        List<Flight> flights = JsonConvert.DeserializeObject<List<Flight>>(json);
        return flights ?? new List<Flight>();
    }

    public void WriteDateToJson(List<Flight> flights)
    {
        string json = JsonConvert.SerializeObject(flights, Formatting.Indented);

        using (StreamWriter streamWriter = File.CreateText(pathfile))
        {
            streamWriter.Write(json);
        }
    }

}