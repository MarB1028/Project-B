using Newtonsoft.Json;
public class Account
{
    public int ID;
    private static int _counter = 0;
    public bool LoggedIn;
    public string Email;

    [JsonProperty(Order = 2)] // veranderd de volgorde binnen het json bestand waardoor de list met tickets altijd onderaan staat
    public List<BookTicket> BoughtTickets;
    public List<Voucher> Vouchers;

    [JsonProperty(Order = 1)]
    public string Password { get; set; }

    public Account(string email, string password)
    {
        ID = ++_counter;
        LoggedIn = false;
        Email = email;
        Password = password;
        BoughtTickets = new List<BookTicket>();
        Vouchers = new List<Voucher>();
    }
}