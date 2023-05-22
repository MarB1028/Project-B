public class Passenger
{
    public static int PreviousID = 0;
    public int ID;
    public string FirstName;
    public string SurName;
    public string Gender;
    public DateTime BirthDate;
    public string Adress;
    public string PhoneNumber;

    public Passenger(string firstname, string surname, string gender, DateTime birthDate, string adress, string phoneNumber)
    {
        ID = PreviousID + 1;
        PreviousID = ID;
        FirstName = firstname;
        SurName = surname;
        Gender = gender;
        BirthDate = birthDate;
        Adress = adress;
        PhoneNumber = phoneNumber;
    }
}