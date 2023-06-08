static class Login
{
    public static void LoginChecker() //checkt of user is ingelogd of niet
    {
        List<Account> accounts = SetGetAccounts.ReadAccountsFromJSON();
        bool isLoggedIn = false;

        foreach (Account account in accounts)
        {
            if (account.LoggedIn)
            {
                isLoggedIn = true;
                break;
            }
        }

        if (isLoggedIn)
        {
            Console.WriteLine($"You are already logged in.");
            Console.WriteLine("If you would like to log in with another account, please log out first.");
            Console.WriteLine("\nPress ENTER to go back to main menu.");
            Console.ReadKey();
            Console.Clear();
            Menu.StartScreen();
        }
        else
        {
            LoginpageMessage();
        }
    }
    public static void LoginpageMessage()
    {
        Console.WriteLine("Welcome to the login page");
        Console.WriteLine("===============================================");

        ValidateEmailPassword validateEmailPassword = new();
        validateEmailPassword.CheckLoginOrRegister();
    }

    public static void LoggedInMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Welcome passenger! What is our next destination?");
        Menu.StartScreen();

    }
}