using AnimalLibrary;
using AnimalLibrary.Animals;
using AnimalLibrary.Items.Properties;
using DataProcessing.Checking.Validation;

namespace ApplicationTests.Validators;

public class ObjectValidatorsTest
{
    private AnimalDataChecker _animalChecker;
    private InventoryDataChecker _inventoryChecker;

    [SetUp]
    public void Setup()
    {
        _animalChecker = new();
        _inventoryChecker = new();
    }

    [Test]
    public void TestAnimalDataCheckerValidAnimalReturnsTrue()
    {
        var predator = new TestPredator() { Name = "Tiger", Age = 10 };
        var herbo = new TestHerbo() { Name = "Rabbit", Age = 5, Kindness = 3 };

        Assert.That(_animalChecker.Check(predator), Is.EqualTo(true));
        Assert.That(_animalChecker.Check(herbo), Is.EqualTo(true));
    }

    [Test]
    public void TestAnimalDataCheckerInvalidNameReturnsFalse()
    {
        var invalid1 = new TestPredator() { Name = "", Age = 10 };
        var invalid2 = new TestPredator() { Name = new string('A', 101), Age = 10 };

        Assert.That(_animalChecker.Check(invalid1), Is.EqualTo(false));
        Assert.That(_animalChecker.Check(invalid2), Is.EqualTo(false));
    }

    [Test]
    public void TestAnimalDataCheckerInvalidAgeReturnsFalse()
    {
        var invalid1 = new TestPredator() { Name = "Tiger", Age = -1 };
        var invalid2 = new TestPredator() { Name = "Tiger", Age = 101 };

        Assert.That(_animalChecker.Check(invalid1), Is.EqualTo(false));
        Assert.That(_animalChecker.Check(invalid2), Is.EqualTo(false));
    }

    [Test]
    public void TestAnimalDataCheckerInvalidHerboKindnessReturnsFalse()
    {
        var herboLow = new TestHerbo() { Name = "H1", Age = 10, Kindness = -6 };
        var herboHigh = new TestHerbo() { Name = "H2", Age = 10, Kindness = 11 };

        Assert.That(_animalChecker.Check(herboLow), Is.EqualTo(false));
        Assert.That(_animalChecker.Check(herboHigh), Is.EqualTo(false));
    }

    [Test]
    public void TestInventoryDataCheckerValidInventoryReturnsTrue()
    {
        var inventory = new InventoryTestItem("AB#123", "ItemName", 50);
        Assert.That(_inventoryChecker.Check(inventory), Is.EqualTo(true));
    }

    [Test]
    public void TestInventoryDataCheckerInvalidNumberReturnsFalse()
    {
        var invLow = new InventoryTestItem("AB#123", "Item", -1);
        var invHigh = new InventoryTestItem("AB#123", "Item", 101);

        Assert.That(_inventoryChecker.Check(invLow), Is.EqualTo(false));
        Assert.That(_inventoryChecker.Check(invHigh), Is.EqualTo(false));
    }

    [Test]
    public void TestInventoryDataCheckerInvalidNameReturnsFalse()
    {
        var emptyName = new InventoryTestItem("AB#123", "", 10);
        var longName = new InventoryTestItem("AB#123", new string('A', 51), 10);

        Assert.That(_inventoryChecker.Check(emptyName), Is.EqualTo(false));
        Assert.That(_inventoryChecker.Check(longName), Is.EqualTo(false));
    }

    [Test]
    public void TestInventoryDataCheckerInvalidIdFormatReturnsFalse()
    {
        var invalid1 = new InventoryTestItem("A#123", "Item", 10);
        var invalid2 = new InventoryTestItem("ABC123", "Item", 10);
        var invalid3 = new InventoryTestItem("AB#12", "Item", 10);

        Assert.That(_inventoryChecker.Check(invalid1), Is.EqualTo(false));
        Assert.That(_inventoryChecker.Check(invalid2), Is.EqualTo(false));
        Assert.That(_inventoryChecker.Check(invalid3), Is.EqualTo(false));
    }

    private class InventoryTestItem(string id, string name, int number) : IInventory, IHasName
    {
        public string Id { get; set; } = id;
        public string ItemName { get; set; } = name;

        public string GetTypeName()
        {
            return "";
        }

        public int Number { get; set; } = number;
    }

    private class TestPredator : Predator
    {
        public TestPredator()
        {
            Name = "Test";
            Age = 25;
            FoodNeeded = 5;
            IsNeutered = false;
        }
    }

    private class TestHerbo : Herbo
    {
        public TestHerbo()
        {
            Name = "Test";
            Age = 25;
            Kindness = 0;
            FoodNeeded = 5;
            IsNeutered = false;
        }
    }
}