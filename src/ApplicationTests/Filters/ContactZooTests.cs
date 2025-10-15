using AnimalLibrary.Animals;
using DataProcessing.Checking.Filters.Contact;

namespace ApplicationTests.Filters;

public class ContactZooTests
{
    private ContactFilter _filter;

    [SetUp]
    public void Setup()
    {
        _filter = new();
    }

    [Test]
    public void TestContactFilterHerboKindnessAboveFive()
    {
        var herbo = new Rabbit() { Kindness = 7 };
        var result = _filter.Check(herbo);
        Assert.That(result, Is.EqualTo(true));
    }

    [Test]
    public void TestContactFilterHerboKindnessEqualFive()
    {
        var herbo = new Monkey() { Kindness = 5 };
        var result = _filter.Check(herbo);
        Assert.That(result, Is.EqualTo(false));
    }

    [Test]
    public void TestContactFilterHerboKindnessBelowFive()
    {
        var herbo = new Rabbit() { Kindness = 3 };
        var result = _filter.Check(herbo);
        Assert.That(result, Is.EqualTo(false));
    }

    [Test]
    public void TestContactFilterNonHerboAnimal()
    {
        var tiger = new Tiger() { FoodNeeded = 10 };
        var result = _filter.Check(tiger);
        Assert.That(result, Is.EqualTo(false));
    }

    [Test]
    public void TestContactFilterNullAnimalThrows()
    {
        Animal animal = null!;
        Assert.Throws<ArgumentNullException>(() => _filter.Check(animal));
    }
}