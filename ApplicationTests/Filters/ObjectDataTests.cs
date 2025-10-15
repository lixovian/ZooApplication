using AnimalLibrary;
using AnimalLibrary.Animals;
using AnimalLibrary.Items.Properties;
using DataProcessing.Checking;
using DataProcessing.Containers;
using Moq;

namespace ApplicationTests.Filters;

public class ObjectDataTests
{
    private AnimalData _animalData;
    private InventoryData _inventoryData;

    [SetUp]
    public void Setup()
    {
        _animalData = new();
        _inventoryData = new();
    }

    [Test]
    public void TestObjectDataAddValidAnimalReturnsTrue()
    {
        var animal = new TestPredator();
        var result = _animalData.Add(animal);
        Assert.That(result, Is.EqualTo(true));
        Assert.That(_animalData.At(0), Is.EqualTo(animal));
    }

    [Test]
    public void TestObjectDataAddInvalidAnimalThrowsInvalidDataException()
    {
        var animal = new TestPredator() {Age = -5};
        Assert.Throws<InvalidDataException>(() => _animalData.Add(animal));
    }

    [Test]
    public void TestObjectDataAddOldAnimalReturnsFalse()
    {
        var oldAnimal = new TestPredator() { Age = 100};
        var result = _animalData.Add(oldAnimal);
        Assert.That(result, Is.EqualTo(false));
    }

    [Test]
    public void TestObjectDataRemoveExistingAnimalReturnsTrue()
    {
        var rabbit = new TestHerbo();
        _animalData.Add(rabbit);
        var result = _animalData.Remove(rabbit);
        Assert.That(result, Is.EqualTo(true));
    }

    [Test]
    public void TestObjectDataRemoveMissingAnimalReturnsFalse()
    {
        var tiger = new TestPredator();
        var result = _animalData.Remove(tiger);
        Assert.That(result, Is.EqualTo(false));
    }

    [Test]
    public void TestObjectDataAtReturnsCorrectElement()
    {
        var monkey = new TestHerbo();
        _animalData.Add(monkey);
        var result = _animalData.At(0);
        Assert.That(result, Is.EqualTo(monkey));
    }

    [Test]
    public void TestObjectDataAtThrowsForInvalidIndex()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _animalData.At(5));
    }

    [Test]
    public void TestObjectDataGetAllReturnsFullList()
    {
        var wolf = new TestPredator();
        var tiger = new TestPredator();
        _animalData.Add(wolf);
        _animalData.Add(tiger);
        var all = _animalData.GetAll();
        Assert.That(all.Count, Is.EqualTo(2));
        Assert.Contains(wolf, all);
        Assert.Contains(tiger, all);
    }

    [Test]
    public void TestObjectDataGetFilterDataReturnsFilteredResult()
    {
        var wolf = new TestPredator() {Age = 10};
        var rabbit = new TestHerbo() {Age = 4};
        _animalData.Add(wolf);
        _animalData.Add(rabbit);

        var mockChecker = new Mock<IChecker<Animal>>();
        mockChecker.Setup(x => x.Check(It.IsAny<Animal>())).Returns<Animal>(a => a.Age < 5);

        var result = _animalData.GetFilterData(mockChecker.Object);
        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result[0], Is.EqualTo(rabbit));
    }

    [Test]
    public void TestInventoryDataAddValidInventoryReturnsTrue()
    {
        var obj = new InventoryTestItem();
        var result = _inventoryData.Add(obj);
        Assert.That(result, Is.EqualTo(true));
    }

    [Test]
    public void TestInventoryDataAddInvalidInventoryThrowsInvalidDataException()
    {
        var mockChecker = new Mock<IChecker<IInventory>>();
        var invalidData = new InventoryDataPrivateMock(mockChecker.Object);
        mockChecker.Setup(x => x.Check(It.IsAny<IInventory>())).Returns(false);
        var mockInventory = new Mock<IInventory>().Object;
        Assert.Throws<InvalidDataException>(() => invalidData.Add(mockInventory));
    }

    [Test]
    public void TestObjectDataGetFilterDataWithInventory()
    {
        IInventory table = new InventoryTestItem();
        IInventory computer = new InventoryTestItem();
        _inventoryData.Add(table);
        _inventoryData.Add(computer);

        var mockChecker = new Mock<IChecker<IInventory>>();
        mockChecker.SetupSequence(x => x.Check(It.IsAny<IInventory>()))
            .Returns(true)
            .Returns(false);

        var filtered = _inventoryData.GetFilterData(mockChecker.Object);
        Assert.That(filtered.Count, Is.EqualTo(1));
        Assert.That(filtered[0], Is.EqualTo(table));
    }

    private class InventoryDataPrivateMock(IChecker<IInventory> checker) : InventoryData
    {
        protected override bool IsDataValid(IInventory obj)
        {
            if (!checker.Check(obj))
            {
                throw new InvalidDataException();
            }
            
            return true;
        }
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

    private class InventoryTestItem : IInventory, IHasName
    {
        public string Id { get; set; } = "AA#000";
        public string ItemName { get; set; } = "Name";

        public string GetTypeName()
        {
            return "";
        }

        public int Number { get; set; } = 1;
    }
}
