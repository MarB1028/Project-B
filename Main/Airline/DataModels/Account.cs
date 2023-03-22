class Account
{
    public string Email;
    public string Password { get; private set; }
 
    public Account(string email, string password)
    {
        Email = email;
        Password = password;
    }
}