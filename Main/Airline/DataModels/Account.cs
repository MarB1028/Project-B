class Account
{
    public string Email;
    private string _password;

    public string Password { get; set; }

 
    public Account(string email, string password)
    {
        Email = email;
        Password = password;

    }

    public bool CheckNewValidEmail(string email)
    {
        if (email.Contains("@"))
        {
            Console.WriteLine("Email adress is valid");
            return true;
        }
        else
        {
            Console.WriteLine("Email adress is invalid");
            return false;
        }
    }

    public bool CheckNewValidPassword(string password)
    {
        List<string> SpecialChar = new List<string>() { "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "+", "=", "/", "\\", "|", "[", "]", "{", "}", ";", ":", "<", ">", ".", ",", "?", "!" };
        List<string> Numbers = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        foreach (string character in SpecialChar)
        {
            foreach (string number in Numbers)
            {
                if (password.Length >= 6 && password.Contains(character) && password.Contains(number))
                {
                    Console.WriteLine("Password is valid");
                    return true;
                }
            }
        }
        Console.WriteLine("Password is invalid");
        return false;
    }
}