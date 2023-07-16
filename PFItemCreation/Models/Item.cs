using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace PFItemCreation.Models;

public class Item
{
    public String BaseItem { get; set; }

    public String Name => new Calculations().CalcName(SpecialAbilitiesList, BaseItem, EnhancementBonus);
    
    public ItemType ItemType { get; set; }
    
    public List<SpecialAbilities> SpecialAbilitiesList { get; set; }
    
    public Int32 BaseValue { get; set; }

    public Int16 EnhancementBonus { get; set; }
    
    public Int16 TotalEnhancementBonus => (Int16) (new Calculations().CalcEnhBonus(SpecialAbilitiesList) + EnhancementBonus);

    public Int32 ItemValue => new Calculations().CalcValue(ItemType, SpecialAbilitiesList, BaseValue, TotalEnhancementBonus);
}

[JsonConverter(typeof(StringEnumConverter))]
public enum ItemType
{
    Ammunition,
    Armor,
    Ranged,
    Shield,
    Melee
}