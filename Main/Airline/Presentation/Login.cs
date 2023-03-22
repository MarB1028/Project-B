class Login
{
    public void LoginMessage()
    {
        Console.WriteLine("Welcome to the login page");
        Console.WriteLine("===============================================");

        ValidateEmailPassword validateEmailPassword = new();
        validateEmailPassword.CheckLoginOrRegister();
    }

    // na inloggen -> welcome passager! What is our next destination?
}