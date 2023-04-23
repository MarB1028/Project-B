static class AddFood
{
    public static void FoodAdd(string name, double price, string desc, string type)
    {
        Food food = new Food(name, price, desc, type);

        if (DataFood.WriteFoodToJson(food))
        {
            Console.WriteLine($"{food.Name} Succesfully added to store...");
            AddFoodForm.FoodForm();
        }

        else if (!DataFood.WriteFoodToJson(food))
        {
            Console.WriteLine($"{food.Name} Already in store");
            AddFoodForm.FoodForm();
        }
    }
}