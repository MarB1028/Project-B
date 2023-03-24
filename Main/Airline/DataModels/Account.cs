class Account
{
    public int ID;
    public string Email;
    public string Password { get; set; }

    private static int _counter = 0;

    public Account(string email, string password)
    {
        ID = ++_counter;
        Email = email;
        Password = password;
    }
}