using System.Text;
using PF1eItemCreation;
using PF1eItemCreation.Models;

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
        Assert.AreEqual("Masterwork, Runeforged, Holy, Flaming burst, Cold Iron Large Longsword +1", anyaLongsword.Name);
    }
    
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

        Item marinOpBreastplate = new Item()
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
        
        Assert.AreEqual(48150, marinOpBreastplate.ItemValue);
        Assert.AreEqual("Shadow, Improved Shadow, Mithral Agile Breastplate +5", marinOpBreastplate.Name);
    }

    [TestMethod]
    public void TestRandomItems()
    {
        ItemCreation itemCreation = new ItemCreation();

        Item item1 = new Item
        {
            BaseItem = "Large Longsword",
            BaseValue = 30,
            Weight = 3,
            SpecialMaterial = itemCreation.SpecialMaterials.Find(m => m.Material == "Bone"),
            ItemType = ItemType.Melee
        };
        
        Assert.AreEqual(15, item1.ItemValue);
        Assert.AreEqual("Bone Large Longsword", item1.Name);

        Item item2 = new Item
        {
            BaseItem = "Dagger",
            BaseValue = 2,
            Weight = 1,
            EnhancementBonus = 1,
            SpecialMaterial = itemCreation.SpecialMaterials.Find(m => m.Material == "Nexavaran Steel"),
            ItemType = ItemType.Melee
        };
        
        Assert.AreEqual(5003, item2.ItemValue);
        Assert.AreEqual("Nexavaran Steel Dagger +1", item2.Name);
    }
}
