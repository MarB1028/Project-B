class ValidateEmailPassword
{
    public void CheckLoginOrRegister()
    {
        bool x = true;
        while (x)
        {
            try
            {
                Console.WriteLine("1. Login into your account\n2. Register for a new account\n3. Back to the main menu");
                int loginOrRegister = Convert.ToInt32(Console.ReadLine());

                if (loginOrRegister == 1)
                {
                    CheckLogin();
                    x = false;
                }
                else if (loginOrRegister == 2)
                {
                    SetNewAccount();
                    x = false;
                }
                else if (loginOrRegister == 3)
                {
                    // go back to startscreen
                    Console.WriteLine("back to startscreen");
                    Console.Clear();
                    x = false;
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

    public void SetNewAccount()
    {
        SetGetAccounts setGetAccounts = new();
        List<Account> accounts = setGetAccounts.ReadAccountsFromJSON();

        Console.WriteLine("Input a valid email adress");
        string email = Console.ReadLine()!;
        Console.WriteLine();

        while (CheckNewValidEmail(email) == false)
        {
            Console.WriteLine("Input a valid email adress");
            email = Console.ReadLine()!;
        }

        Console.WriteLine("Input a password (At least 6 characters long,\none special character and one number");
        string password = Console.ReadLine()!;
        Console.WriteLine();

        while (CheckNewValidPassword(password) == false)
        {
            Console.WriteLine("Input a password (At least 6 characters long,\none special character and one number)");
            password = Console.ReadLine()!;
        }

        Account account = new(email, password);
        accounts.Add(account);
        setGetAccounts.WriteAccountToJSON(accounts);
    }

    public bool CheckNewValidEmail(string email)
    {
        List<string> emailEndings = new List<string>() {".nl",".be", ".com", ".org", ".net", ".edu", ".gov", ".co", ".io", ".info", ".mail"};

        if (email.Contains("@"))
        {
            foreach (string ending in emailEndings)
            {
                if (email.Contains(ending))
                {
                    Console.WriteLine("Email adress is valid");
                    return true;
                }
            }
            Console.WriteLine("Email adress is invalid");
            return false;
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

    public void CheckLogin()
    {
        Console.WriteLine("Input your email adress");
        string email = Console.ReadLine()!;

        while (CheckExistingEmail(email) == false)
        {
            Console.WriteLine("The given email does not exist in our system.");
            Console.WriteLine("Input a valid email adress");
            email = Console.ReadLine()!;
        }

        Console.WriteLine("Input your password ");
        string password = Console.ReadLine()!;

        while (CheckExistingPassword(password) == false)
        {
            Console.WriteLine("The given password is incorrect");
            Console.WriteLine("1. Try again\n2. Reset password");
            int answer = Convert.ToInt32((Console.ReadLine()!));

            if (answer == 1)
            {
                Console.WriteLine("Input your password");
                password = Console.ReadLine()!;
            }
            else if (answer == 2)
            {
                Console.WriteLine("Enter your email to reset your password");
                email = Console.ReadLine()!;
                ResetPassword(email);

                if (CheckExistingEmail(email) == true && ResetPassword(email) == true)
                {
                    Console.WriteLine("You logged in succesfully");
                }
                else if (CheckExistingEmail(email) == true && CheckExistingPassword(password) == true)
                {
                    // Account account = new(email, password);
                    Console.WriteLine("You logged in succesfully");
                }
                else
                {
                    Console.WriteLine("Create a new account? y/n");
                    // make new account or go to menu
                }
            }
        }   
    }

    public bool CheckExistingEmail(string email)
    {
        SetGetAccounts setGetAccounts = new();
        List<Account> accounts = setGetAccounts.ReadAccountsFromJSON();

        foreach (Account account in accounts)
        {
            if (account.Email == email)
            {
                return true;
            }
        }

        return false;
    }

    public bool CheckExistingPassword(string password)
    {
        SetGetAccounts setGetAccounts = new();
        List<Account> accounts = setGetAccounts.ReadAccountsFromJSON();

        foreach (Account account in accounts)
        {
            if (account.Password == password)
            {
                return true;
            }
        }
        return false;
    }

    public bool ResetPassword(string email)
    {
        SetGetAccounts setGetAccounts = new SetGetAccounts();
        List<Account> accounts = setGetAccounts.ReadAccountsFromJSON();

        foreach (Account account in accounts)
        {
            if (account.Email == email)
            {
                Console.WriteLine("Input a new password (At least 6 characters long,\none special character and one number)");
                string newPassword = Console.ReadLine()!;

                while (CheckNewValidPassword(newPassword) == false)
                {
                    Console.WriteLine("Input a new password (At least 6 characters long,\none special character and one number)");
                    newPassword = Console.ReadLine()!;
                }

                account.Password = newPassword;
                Console.WriteLine("Password changed successfully!");
                setGetAccounts.WriteAccountToJSON(accounts);
                return true;
            }
        }

        Console.WriteLine("The given email does not exist in our system.");
        return false;
    }
}