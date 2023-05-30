namespace MSTest

{
    [TestClass]
    public class MS_unittest_output
    {
        [TestMethod]
        public void Check_CalculateSeatPrice()
        {
            CalculateSeatPrice obj = new CalculateSeatPrice();
            double expectedPrice = obj.CalculateSeat("ExtraSpace-Class");

            Assert.AreEqual(expectedPrice, 175);
        }

        [TestMethod]
        public void Check_CalculateCateringPrice()
        {
            CateringLogic.basketItems = new List<BasketItem>() 
            { 
                new BasketItem(new Food(1, "test", 5.50, "test", "test"), 2),
                new BasketItem(new Food(2, "test", 2.25, "test", "test"), 5),
                new BasketItem(new Food(3, "test", 3.75, "test", "test"), 3),
                new BasketItem(new Food(4, "test", 7.25, "test", "test"), 2)
            };

            CateringLogic.CalculateTotalCost();
            Assert.AreEqual(CateringLogic.TotalPrice, 48);
        }

        [TestMethod]
        public void Check_CalculateLuggagePrice(int handLuggage, int luggage, double expectedTotalCost)
        {
            GetLugage.tickets = new List<BookTicket>()
        {
            new BookTicket(new Ticket(new Passenger(null, null, null, DateTime.Now, null, null), null, new Seat(null, null, 100), null))
        };

            GetLugage.amountOfHandLuggage = handLuggage;
            GetLugage.amountOfLuggage = luggage;

            GetLugage.CostsAllLuggage();

            Assert.AreEqual(expectedTotalCost, GetLugage.TotalCost);
        }

        [TestMethod]
        public void Check_CalculateTotalPrice()
        {
            DateTime date = new DateTime(2003, 5, 29);

            CalculateTotalCosts.tickets = new List<BookTicket>()
            {
                new BookTicket(new Ticket(new Passenger(null, null, null, date, null, null), null, new Seat(null, null, 100), null))
            };
            
            GetLugage.TotalCost = 100;
            CateringLogic.TotalPrice = 25;

            double price = CalculateTotalCosts.GetTotalPrice();

            Assert.AreEqual(price, 225);
        }
    }
}