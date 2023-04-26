public class CalculateSeatPrice
{
    public double totalprice;
    public double BasePrice = 100;
    public double CalculateSeat(string seattype) {
        //in de toekomst wordt met flight gecheckt hoeveel tijd nog tot de vlucht en wordt de prijsophoging/deals toegepast. 
        //De prijsophoging/deals passen de basisprijs aan
        if (seattype == "First-Class") {
            totalprice = BasePrice * 6;
        }
        else if (seattype == "Premium-Class") {
            totalprice = BasePrice * 3;
        }
        else if (seattype == "ExtraSpace-Class") {
            totalprice = BasePrice + 75;
        }
        else if (seattype == "Economy-Class") {
            totalprice = BasePrice;
        }

        return totalprice;
    }
}