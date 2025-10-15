namespace AnimalLibrary.Items.Fabrics;

public class ThingFabric : IInventoryFabric
{
    public IInventory Create()
    {
        return new Thing();
    }
}