class ValidateEmailPassword
{
    private string _username = "admin";
    private string _password = "admin";

    public void CheckLoginOrRegister() // check of de gebruiker wilt inloggen/registeren of terug wilt gaan naar het menu
    {
        bool x = true;

        while (x)
        {
            try
            {
                Console.WriteLine("1. Login into your account\n2. Register for a new account\n3. Admin login\n4. Back to the main menu");
                int loginOrRegister = Convert.ToInt32(Console.ReadLine());

                if (loginOrRegister == 1) // login met bestaande account
                {
                    Console.Clear();
                    CheckLogin();
                    // ga naar overzicht beschikbare tickets na het registreren of het menu?
                }
                else if (loginOrRegister == 2) // register nieuw account
                {
                    Console.Clear();
                    SetNewAccount();
                    // ga naar overzicht beschikbare tickets na het registreren of het menu?
                }
                else if (loginOrRegister == 3) // admin login
                {
                    Console.Clear();

                    string username;
                    do
                    {
                        Console.Write("Username: ");
                        username = Console.ReadLine()!;
                        if (username == _username)
                        {
                            x = false;
                            break;
                        }
                        else Console.WriteLine("INVALID ADMIN USERNAME.");

                    } while (true);

                    string password;
                    do
                    {
                        Console.Write("Password: ");
                        password = Console.ReadLine()!;
                        if (password == _password)
                        {
                            x = false;
                            break;
                        }
                        else Console.WriteLine("INVALID ADMIN PASSWORD.");

                    } while (true);

                    AdminForm.StartForm();
                }
                else if (loginOrRegister == 4) // terug naar het hoofdmenu
                {
                    Console.Clear();
                    Menu.StartScreen();
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid format!");
            }
        }
    }

    public void SetNewAccount() // nieuwe account aanmaken
    {
        List<Account> accounts = SetGetAccounts.ReadAccountsFromJSON();

        Console.WriteLine("Input a valid email adress:");
        string email = Console.ReadLine()!;
        Console.WriteLine();

        while (CheckNewValidEmail(email) == false) // roept CheckNewValideEmail() aan en checkt de criteria van een email
        {
            Console.WriteLine("Input a valid email adress:");
            email = Console.ReadLine()!;
        }

        Console.WriteLine("Input a password (At least 6 characters long,\none special character and one number).");
        string password = Console.ReadLine()!;
        Console.WriteLine();

        while (CheckNewValidPassword(password) == false) // roept CheckNewValidePassword() aan en checkt de criteria van een wachtwoord
        {
            Console.WriteLine("Input a password (At least 6 characters long,\none special character and one number).");
            password = Console.ReadLine()!;
        }

        Account account = new(email, password);
        account.LoggedIn = true; // Zodra je een account heb aangemaakt ben je gelijk ingelogt!

        accounts.Add(account);
        SetGetAccounts.WriteAccountToJSON(accounts);

        Login.LoggedInMessage();
    }

    public bool CheckNewValidEmail(string email) // checkt of de email aan de criteria voldoet
    {
        List<string> emailEndings = new List<string>() { "@icloud.com", "@hotmail.com", "@gmail.com", "@outlook.com", "@yahoo.com", "@kpnmail.nl", "@ziggo.nl", "@upcmail.nl", "@live.nl", "@telfort.nl", "@xs4all.nl", "@planet.nl" };

        foreach (string ending in emailEndings)
        {
            if (email.EndsWith(ending))
            {
                Console.WriteLine("Email adress is valid.");
                return true;
            }
        }
        Console.WriteLine("Email adress is invalid.");
        return false;
    }

    public bool CheckNewValidPassword(string password) // checkt of het wachtwoord aan de criteria voldoet
    {
        List<string> SpecialChar = new List<string>() { "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "+", "=", "/", "|", "[", "]", "{", "}", ";", ":", "<", ">", ".", ",", "?", "!", "_", "~"};
        List<string> Numbers = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        foreach (string character in SpecialChar)
        {
            foreach (string number in Numbers)
            {
                if (password.Length >= 6 && password.Contains(character) && password.Contains(number))
                {
                    Console.WriteLine("Password is valid.");
                    return true;
                }
            }
        }
        Console.WriteLine("Password is invalid");
        return false;
    }

    public void CheckLogin() // inloggen met bestaande account (checkt json file)
    {
        Console.WriteLine("In order to login you need to have an account\nDo you have an existing account?\n1. Yes\n2. No");
        int userInput = Convert.ToInt32(Console.ReadLine()!);
        try
        {
            if (userInput == 1)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Input your email adress:");
                string email = Console.ReadLine()!;

                while (CheckExistingEmail(email) == false)
                {
                    Console.WriteLine();
                    Console.WriteLine("The given email does not exist in our system.\n1. Try again\n2. Back to menu");
                    int answer = Convert.ToInt32((Console.ReadLine()!));

                    if (answer == 1)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Input your email adress:");
                        email = Console.ReadLine()!;
                    }
                    else if (answer == 2)
                    {
                        Menu.StartScreen();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Input your password:");
                string password = Console.ReadLine()!;

                while (CheckExistingPassword(email, password) == false)
                {
                    Console.WriteLine();
                    Console.WriteLine("Incorrect password.");
                    Console.WriteLine("1. Try again\n2. Reset password\n3. Back to menu");
                    int answer = Convert.ToInt32((Console.ReadLine()!));

                    if (answer == 1)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Input your password:");
                        password = Console.ReadLine()!;
                    }
                    else if (answer == 2)
                    {
                        bool y = true;
                        while (y)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Enter your email to reset your password:");
                            email = Console.ReadLine()!;

                            if (ResetPassword(email) == true)
                            {
                                CheckLoginOrRegister();
                                return;
                            }
                        }
                    }
                    else if (answer == 3)
                    {
                        Menu.StartScreen();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                Console.WriteLine("You logged in succesfully!");
                Console.Clear();
                ChangeLoggingStatus(email);
                Login.LoggedInMessage();
            }
            else if (userInput == 2)
            {
                CheckLoginOrRegister();
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid format!");
        }

    }

    public void ChangeLoggingStatus(string email) // veranderd login status van bestaande accounts naar true
    {
        List<Account> accounts = SetGetAccounts.ReadAccountsFromJSON();

        foreach (Account account in accounts)
        {
            if (account.Email == email)
            {
                account.LoggedIn = true;
                SetGetAccounts.WriteAccountToJSON(accounts);
            }
        }
    }

    public bool CheckExistingEmail(string email) // checkt of ingevulde email overeenkomt met een email in het json bestand
    {
        List<Account> accounts = SetGetAccounts.ReadAccountsFromJSON();

        foreach (Account account in accounts)
        {
            if (account.Email == email)
            {
                return true;
            }
        }
        return false;
    }

    public bool CheckExistingPassword(string email, string password) // checkt of ingevulde wachtwoord overeenkomt met het wachtwoord in het json bestand.
    {
        List<Account> accounts = SetGetAccounts.ReadAccountsFromJSON();

        foreach (Account account in accounts)
        {
            if (account.Email == email && account.Password == password)
            {
                return true;
            }
        }
        return false;
    }

    public bool ResetPassword(string email) // reset het wachtwoord in het json bestand
    {
        List<Account> accounts = SetGetAccounts.ReadAccountsFromJSON();

        foreach (Account account in accounts)
        {
            if (account.Email == email)
            {
                Console.WriteLine();
                Console.WriteLine("Input a new password (At least 6 characters long,\none special character and one number).");
                string newPassword = Console.ReadLine()!;

                while (CheckNewValidPassword(newPassword) == false)
                {
                    Console.WriteLine();
                    Console.WriteLine("Input a new password (At least 6 characters long,\none special character and one number).");
                    newPassword = Console.ReadLine()!;
                }

                account.Password = newPassword;
                Console.WriteLine("Password changed successfully!");
                SetGetAccounts.WriteAccountToJSON(accounts);
                return true;
            }
        }
        Console.WriteLine("The given email does not exist in our system.");
        return false;
    }
}
