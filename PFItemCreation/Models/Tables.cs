namespace PFItemCreation.Models;

public class Tables
{
    /// <summary>
    /// Store the weapon bonus and base value in a table
    /// </summary>
    public IDictionary<Int16, Int32> WeaponTable { get; set; }
    
    /// <summary>
    /// Store the weapon bonus and base value in a table
    /// </summary>
    public IDictionary<Int16, Int32> ArmorTable { get; set; }
}