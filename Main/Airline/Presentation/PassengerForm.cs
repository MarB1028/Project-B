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
        string birthDate0;
        Console.WriteLine("Geboortedatum (DD-MM-JJJJ): ");
        birthDate0 = Console.ReadLine();
        DateTime birthDate = DateTime.Parse(birthDate0);


        //Adres (straat huisnummer postcode stad)
        string street;
        string housenumber;
        string zipcode;
        string city;
        Console.WriteLine("Straat: ");
        street = Console.ReadLine();
        Console.WriteLine("Huisnummer: ");
        housenumber = Console.ReadLine();
        Console.WriteLine("Postcode: ");
        zipcode = Console.ReadLine();
        Console.WriteLine("Stad: ");
        city = Console.ReadLine();
        string adress = $"{street} {housenumber} {zipcode} {city}";

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