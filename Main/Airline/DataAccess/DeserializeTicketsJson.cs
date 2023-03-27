using Newtonsoft.Json;
class DeserialzeTicketsJson
{
    public Flight flight;
    public List<BookTicket> GetList(){
        string pathfile = $"C:\\Users\\marie\\OneDrive - Hogeschool Rotterdam\\Semester 2\\Project B\\Project-B\\Main\\Airline\\DataSources\\BOEING747-ID1-GER1.json";
        if (!File.Exists(pathfile))
        {
            return new List<BookTicket>();
        }

        string json = File.ReadAllText(pathfile);
        List<BookTicket> flights = JsonConvert.DeserializeObject<List<BookTicket>>(json);
        return flights ?? new List<BookTicket>();
    }
}