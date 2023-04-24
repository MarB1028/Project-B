static class AddFoodForm
{
    public static void FoodForm()
    {
        Console.Clear();
        Console.WriteLine("Please enter the specific product");
        Console.WriteLine("======================================");
        
        Console.Write("Name: ");
        string inputName = Console.ReadLine();

        Console.Write("Price: ");
        double inputPrice = Convert.ToDouble(Console.ReadLine());

        Console.Write("Description: ");
        string inputDescription = Console.ReadLine();

        Console.Write("Type: ");
        string inputType = Console.ReadLine();

        AddFood.FoodAdd(inputName, inputPrice, inputDescription, inputType);
    }
}