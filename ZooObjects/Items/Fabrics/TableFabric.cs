namespace AnimalLibrary.Items.Fabrics;

public class TableFabric : IInventoryFabric
{
    public IInventory Create()
    {
        return new Table();
    }
}