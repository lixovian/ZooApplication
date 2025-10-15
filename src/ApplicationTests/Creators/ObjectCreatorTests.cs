using AnimalLibrary.Animals.Fabrics;
using AnimalLibrary.Items.Fabrics;
using DataProcessing.Create;

namespace ApplicationTests.Creators;

public class ObjectCreatorTests
{
    private AnimalCreator _animalCreator;
    private InventoryCreator _inventoryCreator;

    [SetUp]
    public void Setup()
    {
        _animalCreator = new();
        _inventoryCreator = new();
    }

    [Test]
    public void TestObjectCreatorGetCreatorReturnsCorrectAnimalFabric()
    {
        var creator = _animalCreator.GetCreator("Обезьяна");
        Assert.IsInstanceOf<MonkeyFabric>(creator);

        creator = _animalCreator.GetCreator("Кролик");
        Assert.IsInstanceOf<RabbitFabric>(creator);

        creator = _animalCreator.GetCreator("Тигр");
        Assert.IsInstanceOf<TigerFabric>(creator);

        creator = _animalCreator.GetCreator("Волк");
        Assert.IsInstanceOf<WolfFabric>(creator);
    }

    [Test]
    public void TestObjectCreatorGetCreatorReturnsCorrectInventoryFabric()
    {
        var creator = _inventoryCreator.GetCreator("Компьютер");
        Assert.IsInstanceOf<ComputerFabric>(creator);

        creator = _inventoryCreator.GetCreator("Стол");
        Assert.IsInstanceOf<TableFabric>(creator);

        creator = _inventoryCreator.GetCreator("Предмет");
        Assert.IsInstanceOf<ThingFabric>(creator);
    }

    [Test]
    public void TestObjectCreatorGetCreatorThrowsForUnknownAnimalType()
    {
        Assert.Throws<KeyNotFoundException>(() => _animalCreator.GetCreator("Неизвестный"));
    }

    [Test]
    public void TestObjectCreatorGetCreatorThrowsForUnknownInventoryType()
    {
        Assert.Throws<KeyNotFoundException>(() => _inventoryCreator.GetCreator("Неизвестный"));
    }

    [Test]
    public void TestObjectCreatorGetCreatorThrowsForNullKey()
    {
        Assert.Throws<ArgumentNullException>(() => _animalCreator.GetCreator(null!));
        Assert.Throws<ArgumentNullException>(() => _inventoryCreator.GetCreator(null!));
    }

    [Test]
    public void TestObjectCreatorGetCreatorConsistencyBetweenNamesAndCreators()
    {
        var animalNames = _animalCreator.GetNames();
        foreach (var name in animalNames)
        {
            var creator = _animalCreator.GetCreator(name);
            Assert.IsNotNull(creator);
        }

        var inventoryNames = _inventoryCreator.GetNames();
        foreach (var name in inventoryNames)
        {
            var creator = _inventoryCreator.GetCreator(name);
            Assert.IsNotNull(creator);
        }
    }

    [Test]
    public void TestObjectCreatorGetNamesAnimalCreatorReturnsExpectedValues()
    {
        var names = _animalCreator.GetNames();
        Assert.That(names.Length, Is.EqualTo(4));
        Assert.Contains("Обезьяна", names);
        Assert.Contains("Кролик", names);
        Assert.Contains("Тигр", names);
        Assert.Contains("Волк", names);
    }

    [Test]
    public void TestObjectCreatorGetNamesInventoryCreatorReturnsExpectedValues()
    {
        var names = _inventoryCreator.GetNames();
        Assert.That(names.Length, Is.EqualTo(3));
        Assert.Contains("Компьютер", names);
        Assert.Contains("Стол", names);
        Assert.Contains("Предмет", names);
    }

    [Test]
    public void TestObjectCreatorGetNamesReturnsUniqueValues()
    {
        var animalNames = _animalCreator.GetNames();
        var inventoryNames = _inventoryCreator.GetNames();

        Assert.That(animalNames.Length, Is.EqualTo(animalNames.Distinct().Count()));
        Assert.That(inventoryNames.Length, Is.EqualTo(inventoryNames.Distinct().Count()));
    }

    [Test]
    public void TestObjectCreatorGetNamesConsistencyWithGetCreator()
    {
        var animalNames = _animalCreator.GetNames();
        foreach (var name in animalNames)
        {
            var creator = _animalCreator.GetCreator(name);
            Assert.IsNotNull(creator);
        }

        var inventoryNames = _inventoryCreator.GetNames();
        foreach (var name in inventoryNames)
        {
            var creator = _inventoryCreator.GetCreator(name);
            Assert.IsNotNull(creator);
        }
    }

    [Test]
    public void TestObjectCreatorGetNamesImmutableResult()
    {
        var names = _animalCreator.GetNames();
        names[0] = "Изменённое значение";
        var namesAfter = _animalCreator.GetNames();

        Assert.AreNotEqual("Изменённое значение", namesAfter[0]);
    }
}