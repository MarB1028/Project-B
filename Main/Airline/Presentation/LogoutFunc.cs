public static class LogoutFunc
{
    public static void LoggingOut()
    {

        List<Account> accounts = SetGetAccounts.ReadAccountsFromJSON();

        foreach (Account account in accounts)
        {
            if (account.LoggedIn == true)
            {
                account.LoggedIn = false;
                SetGetAccounts.WriteAccountToJSON(accounts);
                Console.WriteLine("You are logged out succesfully");
                Thread.Sleep(1000);
                Console.Clear();
            }
            Console.WriteLine("");
            Thread.Sleep(1000);
            Console.Clear();

        }

    }


    public static void LogOut()
    {
        List<Account> accounts = SetGetAccounts.ReadAccountsFromJSON();

        foreach (Account account in accounts)
        {
            if (account.LoggedIn == true)
            {
                account.LoggedIn = false;
                SetGetAccounts.WriteAccountToJSON(accounts);
                Console.WriteLine("You are logged out successfully");
                Thread.Sleep(1000);
                Console.Clear();
                Menu.StartScreen();
                break; 
            }
        }
        Console.WriteLine("No logged in accounts found");
        Thread.Sleep(1000);
        Console.Clear();
        Menu.StartScreen();
    }
}