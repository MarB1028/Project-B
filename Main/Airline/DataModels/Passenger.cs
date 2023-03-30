public class Passenger
{
    public static int PreviousID = 0;
    public int ID;
    public string Surname;
    public string Lastname;
    public string Sex;
    public DateTime BirthDate;
    public string Adress;
    public string PhoneNumber;

    public Passenger(string surname, string lastname, string sex, DateTime birthDate, string adress, string phoneNumber)
    {
        ID = PreviousID + 1;
        PreviousID = ID;
        Surname = surname;
        Lastname = lastname;
        Sex = sex;
        BirthDate = birthDate;
        Adress = adress;
        PhoneNumber = phoneNumber;
    }
}