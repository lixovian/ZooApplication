namespace AnimalLibrary.Items.Fabrics;

public class ComputerFabric : IInventoryFabric
{
    public IInventory Create()
    {
        return new Computer();
    }
}