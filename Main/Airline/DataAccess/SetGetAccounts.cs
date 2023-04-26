using Newtonsoft.Json;

static class SetGetAccounts
{ 
    //static string pathfile = $"C:\\Users\\{Environment.UserName}\\source\\repos\\GitHub\\Project-B\\Main\\Airline\\DataSources\\ACCOUNTS.json";
    static string pathfile = $"C:\\Users\\{Environment.UserName}\\Development_Y1\\projectB\\_project_B Airline\\Project-B\\Main\\Airline\\DataSources\\accounts.json";

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