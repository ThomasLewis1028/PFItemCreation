using PFItemCreation;
using PFItemCreation.Models;

namespace PFICTests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestWeaponCreation()
    {
        ItemCreation itemCreation = new ItemCreation();
        
        Item marinStartingBow = new Item()
        {
            BaseItem = "Darkwood Composite Longbow",
            BaseValue = 430,
            EnhancementBonus = 1,
            SpecialAbilitiesList = new List<SpecialAbilities>
            {
                itemCreation.SpecialAbilities.Find(s => s.Ability == "Adaptive")
            },
            ItemType = ItemType.Ranged
        };
        
        Item marinEndgameBow = new Item()
        {
            BaseItem = "Darkwood Composite Longbow",
            BaseValue = 430,
            EnhancementBonus = 5,
            SpecialAbilitiesList = new List<SpecialAbilities>
            {
                itemCreation.SpecialAbilities.Find(s => s.Ability == "Adaptive"),
                itemCreation.SpecialAbilities.Find(s => s.Ability == "Conserving"),
                itemCreation.SpecialAbilities.Find(s => s.Ability == "Called"),
                itemCreation.SpecialAbilities.Find(s => s.Ability == "Distance"),
                itemCreation.SpecialAbilities.Find(s => s.Ability == "Seeking")
            },
            ItemType = ItemType.Ranged
        };
        
        Item marinShortbow = new Item()
        {
            BaseItem = "Marin's Shortbow",
            BaseValue = 395,
            EnhancementBonus = 2,
            SpecialAbilitiesList = new List<SpecialAbilities>
            {
                itemCreation.SpecialAbilities.Find(s => s.Ability == "Adaptive")
            },
            ItemType = ItemType.Ranged
        };

        Item anyaLongsword = new Item()
        {
            BaseItem = "Cold Iron Longsword",
            BaseValue = 2030,
            EnhancementBonus = 1,
            SpecialAbilitiesList = new List<SpecialAbilities>()
            {
                itemCreation.SpecialAbilities.Find(s => s.Ability == "Runeforged"),
                itemCreation.SpecialAbilities.Find(s => s.Ability == "Holy"),
                itemCreation.SpecialAbilities.Find(s => s.Ability == "Flaming burst")
            },
            ItemType = ItemType.Melee
        };
        
        
        Assert.AreEqual(3430 , marinStartingBow.ItemValue);
        Assert.AreEqual("Adaptive, Darkwood Composite Longbow +1", marinStartingBow.Name);
        Assert.AreEqual(163430 , marinEndgameBow.ItemValue);
        Assert.AreEqual(9395 , marinShortbow.ItemValue);
        Assert.AreEqual(100030 , anyaLongsword.ItemValue);
    }
    
    [TestMethod]
    public void TestArmorCreation()
    {
        ItemCreation itemCreation = new ItemCreation();

        
        Item marinBreastplate = new Item()
        {
            BaseItem = "Mithral, Agile Breastplate +1",
            BaseValue = 4400,
            EnhancementBonus = 1,
            SpecialAbilitiesList = new List<SpecialAbilities>(),
            ItemType = ItemType.Armor
        };
        
        Item marinOPBreastplate = new Item()
        {
            BaseItem = "Improved Shadow, Mithral, Agile Breastplate +5",
            BaseValue = 4400,
            EnhancementBonus = 5,
            SpecialAbilitiesList = new List<SpecialAbilities>()
            {
                itemCreation.SpecialAbilities.Find(s => s.Ability == "Shadow"),
                itemCreation.SpecialAbilities.Find(s => s.Ability == "Improved Shadow"),
            },
            ItemType = ItemType.Armor
        };
        
        Assert.AreEqual(5400 , marinBreastplate.ItemValue);
        Assert.AreEqual(48150 , marinOPBreastplate.ItemValue);
    }
}