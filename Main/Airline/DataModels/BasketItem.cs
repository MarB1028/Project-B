class BasketItem
{
    public Food FoodItem { get; set; }
    public int Quantity { get; set; }

    public BasketItem(Food fooditem, int quantity)
    {
        FoodItem = fooditem;
        Quantity = quantity;
    }
}