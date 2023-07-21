using PFItemCreation.Models;

namespace PFItemCreation;

public class Calculations
{
    /// <summary>
    /// This function will receive an Item (preferably from within the Item class) and then calculate the enhancement
    /// bonus based on how many of the special abilities are added.
    /// </summary>
    /// <param name="item"></param>
    /// <returns>Int16 enhancement bonus value</returns>
    public Int16 CalcEnhBonus(Item item)
    {
        Int16 bonus = 0;

        if(item.SpecialAbilitiesList.Count > 0)
            foreach (var ability in item.SpecialAbilitiesList)
                if (ability.Cost == 0)
                    bonus += ability.EnhancementBonus;

        return bonus;
    }

    /// <summary>
    /// This function will receive an Item (preferably from within the Item class) and then calculate the total value
    /// based on how many of the special abilities and or special materials are added are added.
    /// </summary>
    /// <param name="item"></param>
    /// <returns>Double of the item value calculated from the abilities and materials</returns>
    public Double CalcValue(Item item)
    {
        Double value = item.BaseValue;

        if (item.SpecialMaterial != null)
        {
            var valueTable = item.SpecialMaterial.ValueTables.Find(v => v.Item1 == item.ItemType);
            switch (valueTable.Item2)
            {
                case Modifier.Add:
                    if (valueTable.Item3 == ModBasis.All)
                    {
                        value += valueTable.Item4;
                    }
                    else if (valueTable.Item3 == ModBasis.Weight)
                    {
                        value += item.Weight * valueTable.Item4;
                    }

                    break;
                case Modifier.Subtract:
                    if (valueTable.Item3 == ModBasis.All)
                    {
                        value -= valueTable.Item4;
                    }
                    else if (valueTable.Item3 == ModBasis.Weight)
                    {
                        value -= item.Weight * valueTable.Item4;
                    }

                    break;
                case Modifier.Multiply:
                    if (valueTable.Item3 == ModBasis.All)
                    {
                        value *= valueTable.Item4;
                    }
                    else if (valueTable.Item3 == ModBasis.Weight)
                    {
                        value *= item.Weight * valueTable.Item4;
                    }

                    break;
                case Modifier.Divide:
                    if (valueTable.Item3 == ModBasis.All)
                    {
                        value /= valueTable.Item4;
                    }
                    else if (valueTable.Item3 == ModBasis.Weight)
                    {
                        value /= item.Weight * valueTable.Item4;
                    }

                    break;
            }
            
            if (item.TotalEnhancementBonus > 0 || item.SpecialAbilitiesList.Count > 0)
            {
                var magicIncrease = item.SpecialMaterial.MagicIncrease;

                switch (magicIncrease.Item1)
                {
                    case Modifier.Add:
                        if (magicIncrease.Item2 == ModScale.First)
                        {
                            value += magicIncrease.Item3;
                        }
                        else if (magicIncrease.Item2 == ModScale.All)
                        {
                            value += item.SpecialAbilitiesList.Count * magicIncrease.Item3;
                        }

                        break;
                    case Modifier.Subtract:
                        if (magicIncrease.Item2 == ModScale.First)
                        {
                            value -= magicIncrease.Item3;
                        }
                        else if (magicIncrease.Item2 == ModScale.All)
                        {
                            value -= item.SpecialAbilitiesList.Count * magicIncrease.Item3;
                        }

                        break;
                    case Modifier.Multiply:
                        if (magicIncrease.Item2 == ModScale.First)
                        {
                            value *= magicIncrease.Item3;
                        }
                        else if (magicIncrease.Item2 == ModScale.All)
                        {
                            value *= item.SpecialAbilitiesList.Count * magicIncrease.Item3;
                        }

                        break;
                    case Modifier.Divide:
                        if (magicIncrease.Item2 == ModScale.First)
                        {
                            value /= magicIncrease.Item3;
                        }
                        else if (magicIncrease.Item2 == ModScale.All)
                        {
                            value /= item.SpecialAbilitiesList.Count * magicIncrease.Item3;
                        }

                        break;
                }
            }
        }

        if(item.SpecialAbilitiesList.Count > 0)
            foreach (var ability in item.SpecialAbilitiesList)
                if (ability.Cost > 0)
                    value += ability.Cost;

        switch (item.ItemType)
        {
            case ItemType.Armor:
            case ItemType.LightArmor:
            case ItemType.MediumArmor:
            case ItemType.HeavyArmor:
            case ItemType.Shield:
                value += Globals.Tables.ArmorTable[item.TotalEnhancementBonus];
                value += item.SpecialMaterial != null && (item.Masterwork || item.SpecialMaterial.MwType == MwType.AddIn) ? 150 : 0;
                break;
            case ItemType.Ammunition:
            case ItemType.Ranged:
            case ItemType.Melee:
                value += Globals.Tables.WeaponTable[item.TotalEnhancementBonus];
                value += item.SpecialMaterial != null && (item.Masterwork || item.SpecialMaterial.MwType == MwType.AddIn) ? 300 : 0;
                break;
        }

        return value;
    }

    /// <summary>
    /// This concatenates the item name with the various materials and abilities to make the full item name that would
    /// be seen in-game
    /// </summary>
    /// <param name="item"></param>
    /// <returns>String full name of the item</returns>
    public String CalcName(Item item)
    {
        String itemName = "";

        if (item.Masterwork)
            itemName += "Masterwork, ";

        if(item.SpecialAbilitiesList.Count > 0)
        {
            foreach (var ability in item.SpecialAbilitiesList)
            {
                itemName += ability.Ability + ", ";
            }
        }

        itemName += item.SpecialMaterial != null
            ? item.SpecialMaterial.Material + " " + item.BaseItem
            : item.BaseItem;

        if (item.EnhancementBonus > 0)
        {
            itemName += " +" + item.EnhancementBonus;
        }

        return itemName;
    }
}