using Newtonsoft.Json;

static class SetGetAccounts
{ 
    public static List<Account> ReadAccountsFromJSON()
    {
        string pathfile = $"C:\\Users\\{Environment.UserName}\\OneDrive - Hogeschool Rotterdam\\Semester 2\\Project B\\Project-B\\Main\\Airline\\DataSources\\accounts.json";
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
        string pathfile = $"C:\\Users\\{Environment.UserName}\\OneDrive - Hogeschool Rotterdam\\Semester 2\\Project B\\Project-B\\Main\\Airline\\DataSources\\accounts.json";
        string json = JsonConvert.SerializeObject(accounts, Formatting.Indented);

        using (StreamWriter streamWriter = File.CreateText(pathfile))
        {
            streamWriter.Write(json);
        }
    }
}