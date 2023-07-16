namespace PFItemCreation.Models;

public class SpecialAbilities
{
    /// <summary>
    /// The name of the ability
    /// </summary>
    public String Ability { get; set; }
    
    /// <summary>
    /// The enhancement bonus value
    /// </summary>
    public Int16 EnhancementBonus { get; set; }
    
    /// <summary>
    /// PFSRD Link to the ability
    /// </summary>
    public String Link { get; set; }
    
    /// <summary>
    /// The cost of the upgrade if applicable
    /// </summary>
    public Int32 Cost { get; set; }
    
    public List<ItemType> Types { get; set; }
}