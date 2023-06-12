public class AirplaneSeatInformation
{
    public int FirstClassSeat { get; set; }
    public int PremiumSeat { get; set; }
    public int EconomySeat { get; set; }
    public int ExtraSpace { get; set; }

    public AirplaneSeatInformation(int firstclassseat, int premiumseat, int economyseat, int extraspace)
    {
        FirstClassSeat = firstclassseat;
        PremiumSeat = premiumseat;
        EconomySeat = economyseat;
        ExtraSpace = extraspace;
    }

    public override string ToString()
    {
        return $"Firstclass: {FirstClassSeat}, Premiumseat: {PremiumSeat}, Economyseat: {EconomySeat}, Extraspace: {ExtraSpace}";
    }
}