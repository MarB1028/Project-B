using Newtonsoft.Json;

static class DataFood
{   
    private static string pathfile = $"{GetPathFile.ReturnPathFile()}\\FOODS.json";
    public static void CheckExistingFile()
    {
        List<Food> list = new List<Food>();
        string json = JsonConvert.SerializeObject(list, Formatting.Indented);
        if (!File.Exists(pathfile))
        {
            File.WriteAllText(pathfile, json);
        }
    }

    public static void OverWriteExistingFile(List<Food> list)
    {
        string json = JsonConvert.SerializeObject(list, Formatting.Indented);
        File.WriteAllText(pathfile, json);
    }

    public static List<Food> ReadFoodFromJson(string type)
    {
        CheckExistingFile();

        if (type == "Long")
        {
            string json = File.ReadAllText(pathfile);
            List<Food> DataFood = JsonConvert.DeserializeObject<List<Food>>(json);
            List<Food> LongDataFood = new List<Food>();

            foreach (Food food in DataFood)
            {
                if (food.Type == type)
                {
                    LongDataFood.Add(food);
                }
            }
            return LongDataFood ?? new List<Food>();
        }

        else if (type == "Short")
        {
            string json = File.ReadAllText(pathfile);
            List<Food> DataFood = JsonConvert.DeserializeObject<List<Food>>(json);
            List<Food> ShortDataFood = new List<Food>();

            foreach (Food food in DataFood)
            {
                if (food.Type == type)
                {
                    ShortDataFood.Add(food);
                }
            }
            return ShortDataFood ?? new List<Food>();
        }

        else if (type == "All")
        {
            string json = File.ReadAllText(pathfile);
            List<Food> DataFood = JsonConvert.DeserializeObject<List<Food>>(json);
            return DataFood ?? new List<Food>();
        }
        return null;
    }

    public static bool WriteFoodToJson(Food food)
    {
        List<Food> foodlist = new List<Food>();

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