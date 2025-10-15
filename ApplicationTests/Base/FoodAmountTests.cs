using AnimalLibrary.Animals;
using DataProcessing.Parsers;

namespace ApplicationTests.Base;

public class FoodAmountTests
{
    private AnimalFoodParser _parser;
    
    [SetUp]
    public void Setup()
    {
        _parser = new();
    }
    
    [Test]
    public void TestFoodAmountCalculationBase()
    {
        var animals = new List<Animal>
        {
            new Tiger() { FoodNeeded = 10 },
            new Monkey() {  FoodNeeded = 15 },
            new Rabbit() {  FoodNeeded = 50 }
        };
        
        var result = _parser.GetAmount(animals);

        Assert.That(result, Is.EqualTo(75));
    }

    [Test]
    public void TestFoodAmountCalculationZeroReturn()
    {
        var animals = new List<Animal>();
        var result = _parser.GetAmount(animals);
        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void TestFoodAmountCalculationSingleAnimal()
    {
        var animals = new List<Animal>
        {
            new Wolf() { FoodNeeded = 23 }
        };
        var result = _parser.GetAmount(animals);
        Assert.That(result, Is.EqualTo(23));
    }

    [Test]
    public void TestFoodAmountCalculationExceptionForNull()
    {
        List<Animal> animals = null!;
        Assert.Throws<ArgumentNullException>(() => _parser.GetAmount(animals));
    }
}