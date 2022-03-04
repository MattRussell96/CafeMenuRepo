using CafeMenuRepo;
public class ProgramUI
{

private readonly CafeMenuRepository _cafeMenuRepository = new CafeMenuRepository();
public CafeMenu content = new CafeMenu();
// public CafeMenu newerContent = new CafeMenu();

public void Run()
{
    RunMenu();
}

public void RunMenu()
{
    bool continueToRun = true;
    while (continueToRun)
    {
        Console.Clear();

        Console.WriteLine("Enter the number of the option you would like to select:\n"+
        "1. Show all Menu Items\n"+
        "2. Find menu item by type\n"+
        "3. Find menu item by number\n"+
        "4. Add new menu item\n"+
        "5. Remove menu item\n"+
        "6. Exit");

        string userImput = Console.ReadLine();

        switch(userImput)
        {
            case "1":
            ShowAllContent();
            break;
            case "2":
            ShowContentByType();
            break;
            case "3":
            ShowContentByMenuNumber();
            break;
            case "4":
            CreateNewContent();
            break;
            case "5":
            RemoveContentFromList();
            break;
            case "6":
            continueToRun = false;
            break;
            default:
            Console.WriteLine("Please enter a valid number between 1 and 6.\n"+
            "Press any key to continue............");
            Console.ReadKey();
            break;

        }
    }
}

private void ShowContentByType()
{
    Console.Clear();

    Console.WriteLine("Please enter food type:\n"+
    "White Meat\n"+
    "Red Meat\n"+
    "Pasta\n"+
    "Vegatarian\n"+
    "Soup\n"+
    "Salad\n"+
    "Sandwiches\n"+
    "Deserts");
    

    string name = Console.ReadLine();

    CafeMenu newContent = _cafeMenuRepository.GetContentByTypeOfFood(name);
    {
        if(newContent != null)
        {
        DisplayContent(newContent);
        }
        else
        {
            Console.WriteLine("Invalid Name. Could not find any results!");
        }    
    }

    Console.WriteLine("Press any key to continue...............");
    Console.ReadKey();
}

private void ShowContentByMenuNumber()
{
    CafeMenu newerContent = new CafeMenu();
    
    Console.Clear();

    Console.WriteLine("Enter a Number:");
    
    string number = Console.ReadLine();
    int newNumber = int.Parse(number);

    CafeMenu newestContent = _cafeMenuRepository.GetContentByMenuNumber(newNumber);
    {
        if(newestContent != null)
        {
        DisplayContent(newestContent);
        }
        else
        {
            Console.WriteLine("Invalid Number. Could not find any results!");
        }    
    }

    Console.WriteLine("Press any key to continue...............");
    Console.ReadKey();
}



private void CreateNewContent()
{
    Console.Clear();

    Console.WriteLine("Please enter a menu item:");
    content.MealName = Console.ReadLine();

    Console.WriteLine("Please enter an item number:");
    content.MenuNumber = int.Parse(Console.ReadLine());

    Console.WriteLine("Please select a type of food:\n"+
    "1. White Meat\n"+
    "2. Red Meat\n"+
    "3. Pasta\n"+
    "4. Vegatarian\n"+
    "5. Soup\n"+
    "6. Salad\n"+
    "7. Sandwiches\n"+
    "8. Deserts");
    
    string typeOfFood = Console.ReadLine();
    switch (typeOfFood)
    {
        case "1":
        content.typeOfFood = TypeOfFood.White_Meat;
        break;
        case "2":
        content.typeOfFood = TypeOfFood.Red_Meat;
        break;
        case "3":
        content.typeOfFood = TypeOfFood.Pasta;
        break;
        case "4":
        content.typeOfFood = TypeOfFood.Vegatarian;
        break;
        case "5":
        content.typeOfFood = TypeOfFood.Soup;
        break;
        case "6":
        content.typeOfFood = TypeOfFood.Salad;
        break;
        case "7":
        content.typeOfFood = TypeOfFood.Sandwiches;
        break;
        case "8":
        content.typeOfFood = TypeOfFood.Deserts;
        break;
    }
    
    Console.WriteLine("PLease give us a brief description:");
    content.Description = Console.ReadLine();

    Console.WriteLine("Please list out the ingredients:");
    content.Ingredients = Console.ReadLine();

    _cafeMenuRepository.AddContentToDirectory(content);

}

private void ShowAllContent()
{
    Console.Clear();

    List<CafeMenu> listOfContent = _cafeMenuRepository.GetContents();

    foreach (CafeMenu content in listOfContent)
    {
        DisplayContent(content);
    }
    Console.WriteLine("Press any key to continue...................");
    Console.ReadKey();
}

private void DisplayContent(CafeMenu content)
{
    Console.WriteLine($"Name: {content.MealName}\n"+
    $"Number: {content.MenuNumber}\n"+
    $"Type: {content.typeOfFood}\n"+
    $"Ingredients: {content.Ingredients}\n"+
    $"Description: {content.Description}");
}

private void ShowContentByName()
{
    Console.Clear();

    Console.WriteLine("Enter a Name:");

    string name = Console.ReadLine();

    CafeMenu content = _cafeMenuRepository.GetContentByMealName(name);
    {
        if(content != null)
        {
        DisplayContent(content);
        }
        else
        {
            Console.WriteLine("Invalid Name. Could not find any results!");
        }    
    }

    Console.WriteLine("Press any key to continue...............");
    Console.ReadKey();
}

private void RemoveContentFromList()
{
    Console.Clear();

    Console.WriteLine("Which item would you like to remove?");

    List<CafeMenu> contentList = _cafeMenuRepository.GetContents();

    int count = 0;

    foreach (CafeMenu content in contentList)
    {
        count++;
        Console.WriteLine($"{count}. {content.MealName}");
    }

    int targetContentID = int.Parse(Console.ReadLine());
    int targetIndex = targetContentID - 1;

    if (targetIndex >= 0 && targetIndex < contentList.Count)
    {
        CafeMenu desiredContent = contentList[targetIndex];

        if (_cafeMenuRepository.DeleteExistingContent(desiredContent))
        {
            Console.WriteLine($"{desiredContent.MealName} was successfully removed.");
        }
        else
        {
            Console.WriteLine("I could not complete that action!");
        }
    }
    else
    {
        Console.WriteLine("No content has that ID.");
    }
    Console.WriteLine("Press any key to continue.............");
    Console.ReadKey();

}

}