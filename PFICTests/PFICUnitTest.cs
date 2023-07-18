using PFItemCreation;
using PFItemCreation.Models;

namespace PFICTests;

[TestClass]
public class PFICUnitTest
{
    [TestMethod]
    public void TestWeaponCreation()
    {
        ItemCreation itemCreation = new ItemCreation();

        Item marinStartingBow = new Item()
        {
            BaseItem = "Composite Longbow (+0)",
            BaseValue = 100,
            Weight = 3,
            Masterwork = true,
            EnhancementBonus = 1,
            SpecialAbilitiesList = new List<SpecialAbility>
            {
                itemCreation.SpecialAbilities.Find(s => s.Ability == "Adaptive")
            },
            SpecialMaterial = itemCreation.SpecialMaterials.Find(m => m.Material == "Darkwood"),
            ItemType = ItemType.Ranged
        };

        Item marinEndgameBow = new Item()
        {
            BaseItem = "Composite Longbow (+0)",
            BaseValue = 100,
            Weight = 3,
            Masterwork = true,
            EnhancementBonus = 5,
            SpecialAbilitiesList = new List<SpecialAbility>
            {
                itemCreation.SpecialAbilities.Find(s => s.Ability == "Adaptive"),
                itemCreation.SpecialAbilities.Find(s => s.Ability == "Conserving"),
                itemCreation.SpecialAbilities.Find(s => s.Ability == "Called"),
                itemCreation.SpecialAbilities.Find(s => s.Ability == "Distance"),
                itemCreation.SpecialAbilities.Find(s => s.Ability == "Seeking")
            },
            SpecialMaterial = itemCreation.SpecialMaterials.Find(m => m.Material == "Darkwood"),
            ItemType = ItemType.Ranged
        };

        Item marinShortbow = new Item()
        {
            BaseItem = "Composite Shortbow (+0)",
            BaseValue = 75,
            EnhancementBonus = 2,
            Weight = 2,
            Masterwork = true,
            SpecialAbilitiesList = new List<SpecialAbility>
            {
                itemCreation.SpecialAbilities.Find(s => s.Ability == "Adaptive")
            },
            SpecialMaterial = itemCreation.SpecialMaterials.Find(m => m.Material == "Darkwood"),
            ItemType = ItemType.Ranged
        };

        Item anyaLongsword = new Item()
        {
            BaseItem = "Large Longsword",
            BaseValue = 30,
            EnhancementBonus = 1,
            Weight = 8,
            Masterwork = true,
            SpecialAbilitiesList = new List<SpecialAbility>()
            {
                itemCreation.SpecialAbilities.Find(s => s.Ability == "Runeforged"),
                itemCreation.SpecialAbilities.Find(s => s.Ability == "Holy"),
                itemCreation.SpecialAbilities.Find(s => s.Ability == "Flaming burst")
            },
            SpecialMaterial = itemCreation.SpecialMaterials.Find(m => m.Material == "Cold Iron"),
            ItemType = ItemType.Melee
        };


        Assert.AreEqual(3430, marinStartingBow.ItemValue);
        Assert.AreEqual("Adaptive, Darkwood Composite Longbow (+0) +1", marinStartingBow.Name);
        Assert.AreEqual(163430, marinEndgameBow.ItemValue);
        Assert.AreEqual("Adaptive, Conserving, Called, Distance, Seeking, Darkwood Composite Longbow (+0) +5", marinEndgameBow.Name);
        Assert.AreEqual(9395, marinShortbow.ItemValue);
        Assert.AreEqual("Adaptive, Darkwood Composite Shortbow (+0) +2", marinShortbow.Name);
        Assert.AreEqual(100360, anyaLongsword.ItemValue);
        Assert.AreEqual("Runeforged, Holy, Flaming burst, Cold Iron Large Longsword +1", anyaLongsword.Name);
    }

}

[TestClass]
public class ArmorTest
{
    [TestMethod]
    public void TestArmorCreation()
    {
        ItemCreation itemCreation = new ItemCreation();

        Item marinBreastplate = new Item()
        {
            BaseItem = "Agile Breastplate",
            BaseValue = 400,
            EnhancementBonus = 1,
            Weight = 25,
            SpecialAbilitiesList = new List<SpecialAbility>(),
            SpecialMaterial = itemCreation.SpecialMaterials.Find(m => m.Material == "Mithral"),
            ItemType = ItemType.MediumArmor
        };

        Item marinOPBreastplate = new Item()
        {
            BaseItem = "Agile Breastplate",
            BaseValue = 400,
            EnhancementBonus = 5,
            Weight = 25,
            SpecialAbilitiesList = new List<SpecialAbility>()
            {
                itemCreation.SpecialAbilities.Find(s => s.Ability == "Shadow"),
                itemCreation.SpecialAbilities.Find(s => s.Ability == "Improved Shadow"),
            },
            SpecialMaterial = itemCreation.SpecialMaterials.Find(m => m.Material == "Mithral"),
            ItemType = ItemType.MediumArmor
        };

        Assert.AreEqual(5400, marinBreastplate.ItemValue);
        Assert.AreEqual("Mithral Agile Breastplate +1", marinBreastplate.Name);
        Assert.AreEqual(48150, marinOPBreastplate.ItemValue);
        Assert.AreEqual("Shadow, Improved Shadow, Mithral Agile Breastplate +5", marinOPBreastplate.Name);
    }
    
}