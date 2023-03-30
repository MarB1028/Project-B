using Newtonsoft.Json;

class SetGetAccounts
{
    string pathfile = $"C:\\Users\\{Environment.UserName}\\Development_Y1\\projectB\\_project_B Airline\\Project-B\\Main\\Airline\\DataSources\\accounts.json";
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
        string json = JsonConvert.SerializeObject(accounts);

        using (StreamWriter streamWriter = File.CreateText(pathfile))
        {
            streamWriter.Write(json);
        }
    }
}