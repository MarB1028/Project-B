using Newtonsoft.Json;

static class SetGetAccounts
{ 
    static string pathfile = $"C:\\Users\\soufi\\OneDrive\\Git\\Project B\\Project-B\\Main\\Airline\\DataSources\\ACCOUNTS.json";
    public static List<Account> ReadAccountsFromJSON()
    {
        if (!File.Exists(pathfile))
        {
            return new List<Account>();
        }

        string json = File.ReadAllText(pathfile);
        List<Account> accounts = JsonConvert.DeserializeObject<List<Account>>(json);
        return accounts ?? new List<Account>();
    }

    public static void WriteAccountToJSON(List<Account> accounts)
    {
        string json = JsonConvert.SerializeObject(accounts, Formatting.Indented);

        using (StreamWriter streamWriter = File.CreateText(pathfile))
        {
            streamWriter.Write(json);
        }
    }
}