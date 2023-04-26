class Food
{
    private static int FoodID = 1;
    public int ID;
    public string Name;
    public double Price;
    public string Description;
    public string Type;

    public Food(string name, double price, string description, string type)
    {
        ID = FoodID++;
        Name = name;
        Price = price;
        Description = description;
        Type = type;
    }
}