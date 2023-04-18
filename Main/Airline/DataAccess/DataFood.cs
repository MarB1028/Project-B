using Newtonsoft.Json;

static class DataFood
{
    public static void CheckExistingFile(string path)
    {
        List<Food> list = new List<Food>();
        string json = JsonConvert.SerializeObject(list, Formatting.Indented);
        string pathfile = path;
        if (!File.Exists(pathfile))
        {
            File.WriteAllText(pathfile, json);
        }
    }

    public static List<Food> ReadFoodFromJson()
    {
        string pathfile = $"C:\\Users\\{Environment.UserName}\\Documents\\GitHub\\Project-B\\Main\\Airline\\DataSources\\FOODS.json";
        CheckExistingFile(pathfile);

        string json = File.ReadAllText(pathfile);
        List<Food> DataFood = JsonConvert.DeserializeObject<List<Food>>(json);
        return DataFood ?? new List<Food>();
    }

    public static bool WriteFoodToJson(Food food)
    {
        List<Food> foodlist = new List<Food>();
        string pathfile = $"C:\\Users\\{Environment.UserName}\\Documents\\GitHub\\Project-B\\Main\\Airline\\DataSources\\FOODS.json";

        if (File.Exists(pathfile))
        {
            string json = File.ReadAllText(pathfile);
            foodlist = JsonConvert.DeserializeObject<List<Food>>(json);
        }

        if (!foodlist.Any(f => f.Name == food.Name && f.Price == food.Price))
        {
            foodlist.Add(food);
            string newJson = JsonConvert.SerializeObject(foodlist, Formatting.Indented);
            File.WriteAllText(pathfile, newJson);
            return true;
        }
        return false;
    }
}