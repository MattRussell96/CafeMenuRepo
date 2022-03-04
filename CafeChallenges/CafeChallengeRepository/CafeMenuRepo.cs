namespace CafeMenuRepo;
public class CafeMenuRepository
{
    protected readonly List<CafeMenu> _contentdirectory = new List<CafeMenu>();
    
    public bool AddContentToDirectory(CafeMenu content)
    {
        int startingCount = _contentdirectory.Count;

        _contentdirectory.Add(content);

        bool wasAdded = (_contentdirectory.Count > startingCount) ? true : false;

        return wasAdded;

    }

    public List<CafeMenu> GetContents()
    {
        return _contentdirectory;
    }

    public CafeMenu GetContentByMealName(string MealName)
    {
        foreach (CafeMenu content in _contentdirectory)
        {
            if (content.MealName.ToLower() == MealName.ToLower())
            {
                return content;
            }
        }
        return null;
    }


    public CafeMenu GetContentByTypeOfFood(string typeOfFood)
    {
        foreach (CafeMenu content in _contentdirectory)
        {
            if (content.typeOfFood.ToString().ToLower() == typeOfFood.ToLower())
            {
                return content;
            }
        }
        return null;
    }


    public CafeMenu GetContentByMenuNumber(int MenuNumber)
    {
        foreach (CafeMenu content in _contentdirectory)
        {
            if (content.MenuNumber.ToString().ToLower() == content.MenuNumber.ToString().ToLower())
            {
                return content;
            }
        }
        return null;
    }

    public bool UpdatExistingContent(string originalItem, CafeMenu newContent)
    {
        CafeMenu oldItem = GetContentByMealName(originalItem);

        if (oldItem != null)
        {
            oldItem.MealName = newContent.MealName;
            oldItem.typeOfFood = newContent.typeOfFood;
            oldItem.Ingredients = newContent.Ingredients;
            oldItem.Description = newContent.Description;
            oldItem.MenuNumber = newContent.MenuNumber;

            return true;
        }
        else
        {
            return false;
        }
        
    }
    public bool DeleteExistingContent(CafeMenu existingContent)
    {
        bool deleteResult = _contentdirectory.Remove(existingContent);
        return deleteResult;
    }

}