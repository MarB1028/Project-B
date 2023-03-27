class Airplane
{
    public string Name;
    public string Carrierid;
    public int AirplaneId;
    public int FirstClassSeat;
    public int PremiumSeat;
    public int EconomySeat;
    public int ExtraSpace;

    public Airplane(string name, string carrierintid, int airplaneid, int firstclassseat, int premiumseat, int economyseat, int extraspace)
    {
        Name = name;
        Carrierid = carrierintid;
        AirplaneId = airplaneid;
        FirstClassSeat = firstclassseat;
        PremiumSeat = premiumseat;
        EconomySeat = economyseat;
        ExtraSpace = extraspace;
    }
}