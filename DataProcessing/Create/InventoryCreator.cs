using AnimalLibrary.Items.Fabrics;

namespace DataProcessing.Create;

public class InventoryCreator : ObjectCreator<IInventoryFabric>
{
    private readonly Dictionary<string, IInventoryFabric> _types = new()
    {
        {"Компьютер", new ComputerFabric()},
        {"Стол", new TableFabric()},
        {"Предмет", new ThingFabric()},
    };
    
    protected override Dictionary<string, IInventoryFabric> GetTypes()
    {
        return _types;
    }

    public override string[] GetNames()
    {
        return _types.Keys.ToArray();
    }
}