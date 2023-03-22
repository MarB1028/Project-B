using Newtonsoft.Json;

class LoadDataAccounts
{
    public List<Account> ReadAccountsFromJSON()
    {
        if (!File.Exists("Accounts.json"))
        {
            return new List<Account>();
        }

        string json = File.ReadAllText("Accounts.json");
        List<Account> accounts = JsonConvert.DeserializeObject<List<Account>>(json);
        return accounts ?? new List<Account>();
    }

    public void WriteAccountToJSON(List<Account> accounts)
    {
        string json = JsonConvert.SerializeObject(accounts);

        using (StreamWriter streamWriter = File.CreateText("Accounts.json"))
        {
            streamWriter.Write(json);
        }
    }
}