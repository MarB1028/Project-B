using Newtonsoft.Json;
using System.IO;

class Login
{
    public void LoginMessage()
    {
        Console.WriteLine("Welcome to the login page");
        Console.WriteLine("===============================================");

        CheckLoginOrRegister();
        // na inloggen -> welcome passager! What is our next destination?
    }

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
                    SetNewAccount(); ;
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
        List<Account> accounts = ReadAccountsFromJSON();

        Console.WriteLine("Input a valid email adress");
        string email = Console.ReadLine()!;

        Console.WriteLine("Input a password (At least 6 characters long,\none special character and one number");
        string password = Console.ReadLine()!;

        Account account = new(email, password);

        while (account.CheckNewValidEmail(email) == false)
        {
            Console.WriteLine("Input a valid email adress");
            email = Console.ReadLine()!;
        }

        while (account.CheckNewValidPassword(password) == false)
        {
            Console.WriteLine("Input a password (At least 6 characters long,\none special character and one number");
            password = Console.ReadLine()!;
        }

        accounts.Add(account);
        WriteAccountToJSON(accounts);
    }

    public List<Account> ReadAccountsFromJSON()
    {
        if (!File.Exists("Accounts.json"))
        {
            return new List<Account>();
        }

        string json = File.ReadAllText("Accounts.json");
        List<Account> accounts = JsonConvert.DeserializeObject<List<Account>>(json);
        return accounts ?? new List<Account>();
    }

    public void WriteAccountToJSON(List<Account> accounts)
    {
        string json = JsonConvert.SerializeObject(accounts);

        using (StreamWriter streamWriter = File.CreateText("Accounts.json"))
        {
            streamWriter.Write(json);
        }
    }
}