using Newtonsoft.Json;

class PassengerToJSON
{
    string pathfile = $"C:\\Users\\soufi\\OneDrive\\Git\\Project B\\Project-B\\Main\\Airline\\DataSources\\passengers.json";
    public List<Passenger> ReadPassengersFromJSON()
    {
        if (!File.Exists(pathfile))
        {
            return new List<Passenger>();
        }

        string json = File.ReadAllText(pathfile);
        List<Passenger> passengers = JsonConvert.DeserializeObject<List<Passenger>>(json);
        return passengers ?? new List<Passenger>();
    }

    public void WritePassengerToJSON(List<Passenger> passengers)
    {
        string json = JsonConvert.SerializeObject(passengers, Formatting.Indented);

        using (StreamWriter streamWriter = File.CreateText(pathfile))
        {
            streamWriter.Write(json);
            
            

        }
    }
}