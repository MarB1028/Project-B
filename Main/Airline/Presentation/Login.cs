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
        Console.WriteLine("Welcome passager!\nWhat is our next destination?");
    }
}