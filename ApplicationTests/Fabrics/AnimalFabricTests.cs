using AnimalLibrary.Animals;
using AnimalLibrary.Animals.Fabrics;

namespace ApplicationTests.Fabrics;

public class AnimalFabricTests
{
    private MonkeyFabric _monkeyFabric;
    private RabbitFabric _rabbitFabric;
    private TigerFabric _tigerFabric;
    private WolfFabric _wolfFabric;

    [SetUp]
    public void Setup()
    {
        _monkeyFabric = new();
        _rabbitFabric = new();
        _tigerFabric = new();
        _wolfFabric = new();
    }

    [Test]
    public void TestMonkeyFabricCreatesMonkey()
    {
        var animal = _monkeyFabric.Create();
        Assert.IsNotNull(animal);
        Assert.IsInstanceOf<Monkey>(animal);
    }

    [Test]
    public void TestRabbitFabricCreatesRabbit()
    {
        var animal = _rabbitFabric.Create();
        Assert.IsNotNull(animal);
        Assert.IsInstanceOf<Rabbit>(animal);
    }

    [Test]
    public void TestTigerFabricCreatesTiger()
    {
        var animal = _tigerFabric.Create();
        Assert.IsNotNull(animal);
        Assert.IsInstanceOf<Tiger>(animal);
    }

    [Test]
    public void TestWolfFabricCreatesWolf()
    {
        var animal = _wolfFabric.Create();
        Assert.IsNotNull(animal);
        Assert.IsInstanceOf<Wolf>(animal);
    }

    [Test]
    public void TestEachFabricCreatesNewInstanceEveryTime()
    {
        var tiger1 = _tigerFabric.Create();
        var tiger2 = _tigerFabric.Create();

        Assert.AreNotSame(tiger1, tiger2);
        Assert.IsInstanceOf<Tiger>(tiger1);
        Assert.IsInstanceOf<Tiger>(tiger2);
    }

    [Test]
    public void TestAllFabricsImplementIAnimalFabric()
    {
        Assert.IsInstanceOf<IAnimalFabric>(_monkeyFabric);
        Assert.IsInstanceOf<IAnimalFabric>(_rabbitFabric);
        Assert.IsInstanceOf<IAnimalFabric>(_tigerFabric);
        Assert.IsInstanceOf<IAnimalFabric>(_wolfFabric);
    }

    [Test]
    public void TestCreateReturnsAnimalBaseClass()
    {
        var allFabrics = new List<IAnimalFabric> { _monkeyFabric, _rabbitFabric, _tigerFabric, _wolfFabric };
        foreach (var fabric in allFabrics)
        {
            var animal = fabric.Create();
            Assert.IsInstanceOf<Animal>(animal);
        }
    }
}
