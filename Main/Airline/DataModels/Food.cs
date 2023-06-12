public class Food : IFood
{
    public int ID { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }

    public Food(int id, string name, double price, string description, string type)
    {
        ID = id;
        Name = name;
        Price = price;
        Description = description;
        Type = type;
    }
}