namespace PF2eItemCreation;

public class Rune
{
    public String Name { get; set; }

    public RuneRarity Rarity { get; set; }

    public List<RuneTrait> Traits { get; set; }
    
    public ItemSubCategory SubCategory { get; set; }
    
    public Int16 Level { get; set; }
    
    public Int32 Price { get; set; }

    public (RuneApplication, List<ItemType>) Usage { get; set; }
}


public enum RuneRarity
{
}

public enum RuneTrait
{
}

public enum ItemSubCategory
{
    
}

public enum RuneApplication
{
    
}

public enum ItemType
{
    
}