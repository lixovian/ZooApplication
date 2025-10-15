using AnimalLibrary;
using AnimalLibrary.Items;
using AnimalLibrary.Items.Fabrics;

namespace ApplicationTests.Fabrics;

public class InventoryFabricTests
{
    private ComputerFabric _computerFabric;
    private TableFabric _tableFabric;
    private ThingFabric _thingFabric;

    [SetUp]
    public void Setup()
    {
        _computerFabric = new();
        _tableFabric = new();
        _thingFabric = new();
    }

    [Test]
    public void TestComputerFabricCreatesComputer()
    {
        var item = _computerFabric.Create();
        Assert.IsNotNull(item);
        Assert.IsInstanceOf<Computer>(item);
    }

    [Test]
    public void TestTableFabricCreatesTable()
    {
        var item = _tableFabric.Create();
        Assert.IsNotNull(item);
        Assert.IsInstanceOf<Table>(item);
    }

    [Test]
    public void TestThingFabricCreatesThing()
    {
        var item = _thingFabric.Create();
        Assert.IsNotNull(item);
        Assert.IsInstanceOf<Thing>(item);
    }

    [Test]
    public void TestEachFabricCreatesNewInstanceEveryTime()
    {
        var computer1 = _computerFabric.Create();
        var computer2 = _computerFabric.Create();
        Assert.That(computer2, Is.Not.SameAs(computer1));
        Assert.IsInstanceOf<Computer>(computer1);
        Assert.IsInstanceOf<Computer>(computer2);
    }

    [Test]
    public void TestAllFabricsImplementIInventoryFabric()
    {
        Assert.IsInstanceOf<IInventoryFabric>(_computerFabric);
        Assert.IsInstanceOf<IInventoryFabric>(_tableFabric);
        Assert.IsInstanceOf<IInventoryFabric>(_thingFabric);
    }

    [Test]
    public void TestCreateReturnsIInventoryBaseClass()
    {
        var allFabrics = new List<IInventoryFabric> { _computerFabric, _tableFabric, _thingFabric };
        foreach (var fabric in allFabrics)
        {
            var item = fabric.Create();
            Assert.IsInstanceOf<IInventory>(item);
        }
    }
}