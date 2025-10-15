using AnimalLibrary;

namespace DataProcessing.Checking.Filters.Display;

public class InventoryDisplayFilter : IDisplayFilter<IInventory>
{
    public bool Check(IInventory obj)
    {
        return true;
    }
}