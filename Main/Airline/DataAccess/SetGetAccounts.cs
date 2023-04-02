using Newtonsoft.Json;

class SetGetAccounts
{ 
    string pathfile = $"C:\\Users\\{Environment.UserName}\\Documents\\GitHub\\Project-B\\Main\\Airline\\DataSources\\ACCOUNTS.json";
    public List<Account> ReadAccountsFromJSON()
    {
        if (!File.Exists(pathfile))
        {
            return new List<Account>();
        }

        string json = File.ReadAllText(pathfile);
        List<Account> accounts = JsonConvert.DeserializeObject<List<Account>>(json);
        return accounts ?? new List<Account>();
    }

    public void WriteAccountToJSON(List<Account> accounts)
    {
        string json = JsonConvert.SerializeObject(accounts, Formatting.Indented);

        using (StreamWriter streamWriter = File.CreateText(pathfile))
        {
            streamWriter.Write(json);
        }
    }
}