class Login
{
    public void LoginpageMessage()
    {
        Console.WriteLine("Welcome to the login page");
        Console.WriteLine("===============================================");

        ValidateEmailPassword validateEmailPassword = new();
        validateEmailPassword.CheckLoginOrRegister();
    }

    public void LoggedInMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Welcome passenger! What is our next destination?");
    }
}