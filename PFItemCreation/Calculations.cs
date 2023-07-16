using PFItemCreation.Models;

namespace PFItemCreation;

public class Calculations
{
    public Int16 CalcEnhBonus(List<SpecialAbilities> specialAbilitiesList)
    {
        Int16 bonus = 0;

        foreach (var ability in specialAbilitiesList)
            if (ability.Cost == 0)
                bonus += ability.EnhancementBonus;
        
        return bonus;
    }

    public Int32 CalcValue(ItemType itemType, List<SpecialAbilities> specialAbilitiesList, Int32 baseValue, Int16 bonus)
    {
        Int32 value = baseValue;

        foreach (var ability in specialAbilitiesList)
            if (ability.Cost > 0)
                value += ability.Cost;

        switch (itemType)
        {
            case ItemType.Armor:
            case ItemType.Shield:
                value += Globals.Tables.ArmorTable[bonus];
                break;
            case ItemType.Ammunition:
            case ItemType.Ranged:
            case ItemType.Melee:
                value += Globals.Tables.WeaponTable[bonus];
                break;
        }

        return value;
    }

    public String CalcName(List<SpecialAbilities> specialAbilitiesList, String baseItem, Int16 bonus)
    {
        String itemName = "";

        foreach (var ability in specialAbilitiesList)
        {
            itemName += ability.Ability + ", ";
        }

        itemName += baseItem;

        if (bonus > 0)
        {
            itemName += " +" + bonus;
        }

        return itemName;
    }
}