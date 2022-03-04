namespace CafeMenuRepo;
public class CafeMenu
{
    public string MealName { get; set; }
    public string Ingredients { get; set; }
    public string Description { get; set; }
    public TypeOfFood typeOfFood { get; set; }
    public int MenuNumber { get; set; }

public CafeMenu(){}
public CafeMenu (string mealName, string ingredients, string description, TypeOfFood typeOfFood, int menuNumber)
{
    MealName = mealName;
    Ingredients = ingredients;
    Description = description;
    MenuNumber = menuNumber;
}
}

public enum TypeOfFood
{
    White_Meat,
    Red_Meat,
    Pasta,
    Vegatarian,
    Soup,
    Salad,
    Sandwiches,
    Deserts
}
