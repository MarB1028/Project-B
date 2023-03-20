using System.Text.RegularExpressions;
public static class PassengerForm
{
    public static bool IsAlpha(string input)
    {
        string regex = ".*[a-zA-Z].*";
        return (Regex.IsMatch(input, regex));        
    }

    public static Passenger Form()
    {
        string surname;
        string lastname;
        string sex;
        
        //Voornaam
        do
        {
            Console.WriteLine("Voornaam: ");
            surname = Console.ReadLine();
        }
        while (IsAlpha(surname) == false);

        //Achternaam
        do
        {
            Console.WriteLine("Achternaam: ");
            lastname = Console.ReadLine();
        }
        while (IsAlpha(lastname) == false);

        //Geslacht
        do
        {
            Console.WriteLine("Geslacht (M/V): ");
            sex = Console.ReadLine();
        }
        while (sex.ToUpper().Contains("M") == false || sex.ToUpper().Contains("V"));

        //Geboortedatum
        string birthDate;

        //Adres
        string adress;

        //Maak class
        return new Passenger(surname, lastname, sex, birthDate, adress);
    }
}

public class Passenger
{
    public string Surname;
    public string Lastname;
    public string Sex;
    public DateTime BirthDate;
    public string Adress;

    public Passenger(string Surname, string Lastname, string Sex, DateTime BirthDate, string Adress)
    {
        this.Surname = Surname;
        this.Lastname = Lastname;
        this.Sex = Sex;
        this.BirthDate = BirthDate;
        this.Adress = Adress;
    }

}