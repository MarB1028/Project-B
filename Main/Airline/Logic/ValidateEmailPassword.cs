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
                    // go to method check if input email and password -> to object is same as json file object
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

        Console.WriteLine("Input a password (At least 6 characters long,\none special character and one number");
        string password = Console.ReadLine()!;


        while (CheckNewValidEmail(email) == false)
        {
            Console.WriteLine("Input a valid email adress");
            email = Console.ReadLine()!;
        }

        while (CheckNewValidPassword(password) == false)
        {
            Console.WriteLine("Input a password (At least 6 characters long,\none special character and one number");
            password = Console.ReadLine()!;
        }

        Account account = new(email, password);
        accounts.Add(account);
        setGetAccounts.WriteAccountToJSON(accounts);
    }

    public bool CheckNewValidEmail(string email)
    {
        //check for @ & .com / .nl / etc...
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