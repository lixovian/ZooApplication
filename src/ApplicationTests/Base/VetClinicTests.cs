using AnimalLibrary.Animals;
using DataProcessing.Checking;

namespace ApplicationTests.Base;

public class VetClinicTests
{
    private VetClinicHealthChecker _checker;

    [SetUp]
    public void Setup()
    {
        _checker = new();
    }

    [Test]
    public void TestVetClinicHealthCheckerHealthyAnimal()
    {
        var tiger = new Tiger() { Age = 10 };
        var result = _checker.Check(tiger);
        Assert.That(result, Is.EqualTo(true));
    }

    [Test]
    public void TestVetClinicHealthCheckerTooOldAnimal()
    {
        var monkey = new Monkey() { Age = 60 };
        var result = _checker.Check(monkey);
        Assert.That(result, Is.EqualTo(false));
    }

    [Test]
    public void TestVetClinicHealthCheckerHerboWithNegativeKindness()
    {
        var herbo = new Rabbit() { Age = 5, Kindness = -1 };
        var result = _checker.Check(herbo);
        Assert.That(result, Is.EqualTo(false));
    }

    [Test]
    public void TestVetClinicHealthCheckerHerboWithPositiveKindness()
    {
        var herbo = new Monkey() { Age = 5, Kindness = 3 };
        var result = _checker.Check(herbo);
        Assert.That(result, Is.EqualTo(true));
    }

    [Test]
    public void TestVetClinicHealthCheckerBoundaryAge()
    {
        var rabbit = new Rabbit() { Age = 50 };
        var result = _checker.Check(rabbit);
        Assert.That(result, Is.EqualTo(true));
    }

    [Test]
    public void TestVetClinicHealthCheckerNullAnimalThrows()
    {
        Animal animal = null!;
        Assert.Throws<ArgumentNullException>(() => _checker.Check(animal));
    }
}