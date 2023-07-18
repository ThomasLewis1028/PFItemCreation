using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace PFItemCreation.Models;

public class Item
{
    public String BaseItem { get; set; }

    public String Name => new Calculations().CalcName(this);

    public ItemType ItemType { get; set; }

    public List<SpecialAbility> SpecialAbilitiesList { get; set; }

    public Int32 BaseValue { get; set; }

    public Int32 Weight { get; set; }

    public Int16 EnhancementBonus { get; set; }
    
    public Boolean Masterwork { get; set; }

    public SpecialMaterial SpecialMaterial { get; set; }

    public Int16 TotalEnhancementBonus =>
        (Int16) (new Calculations().CalcEnhBonus(SpecialAbilitiesList) + EnhancementBonus);

    public Int32 ItemValue => new Calculations().CalcValue(this);
}

[JsonConverter(typeof(StringEnumConverter))]
public enum ItemType
{
    Ammunition,
    LightArmor,
    MediumArmor,
    HeavyArmor,
    Armor,
    Clothing,
    Ranged,
    Shield,
    Melee,
    Other
}