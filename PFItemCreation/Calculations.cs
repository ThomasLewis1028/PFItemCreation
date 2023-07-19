using PFItemCreation.Models;

namespace PFItemCreation;

public class Calculations
{
    public Int16 CalcEnhBonus(Item item)
    {
        Int16 bonus = 0;

        if(item.SpecialAbilitiesList.Count > 0)
            foreach (var ability in item.SpecialAbilitiesList)
                if (ability.Cost == 0)
                    bonus += ability.EnhancementBonus;

        return bonus;
    }

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
                value += item.Masterwork ? 150 : 0;
                break;
            case ItemType.Ammunition:
            case ItemType.Ranged:
            case ItemType.Melee:
                value += Globals.Tables.WeaponTable[item.TotalEnhancementBonus];
                value += item.Masterwork ? 300 : 0;
                break;
        }

        return value;
    }

    public String CalcName(Item item)
    {
        String itemName = "";

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