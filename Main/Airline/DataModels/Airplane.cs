public class Airplane : AirplaneSeatInformation
{
    public string Name { get; set; }
    public string Carrierid { get; set; }
    public int AirplaneId { get; set; }

    public Airplane(string name, string carrierintid, int airplaneid, int firstclassseat, int premiumseat, int economyseat, int extraspace) : base(firstclassseat, premiumseat, economyseat, extraspace)
    {
        Name = name;
        Carrierid = carrierintid;
        AirplaneId = airplaneid;
    }
}