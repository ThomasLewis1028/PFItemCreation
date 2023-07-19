using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PFItemCreation.Models;

public class SpecialMaterial
{
    public String Material { get; set; }

    public String Link { get; set; }

    public List<ItemType> Types { get; set; }

    public List<(ItemType, Modifier, ModBasis, Double)> ValueTables { get; set; }
    
    public (Modifier, ModScale, Int32) MagicIncrease { get; set; }
    
    public Boolean Masterwork { get; set; }
}

[JsonConverter(typeof(StringEnumConverter))]
public enum Modifier
{
    Add,
    Subtract,
    Multiply,
    Divide
}

[JsonConverter(typeof(StringEnumConverter))]
public enum ModBasis
{
    All,
    Weight,
    Inch
}

[JsonConverter(typeof(StringEnumConverter))]
public enum ModScale
{
    First,
    All
}



