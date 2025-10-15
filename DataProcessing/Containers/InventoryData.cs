using AnimalLibrary;
using DataProcessing.Checking;
using DataProcessing.Checking.Validation;

namespace DataProcessing.Containers;

public class InventoryData : ObjectData<IInventory>
{
    private readonly IChecker<IInventory> _validChecker = new InventoryDataChecker();

    protected override bool IsDataValid(IInventory obj)
    {
        if (!_validChecker.Check(obj))
        {
            throw new InvalidDataException();
        }
        
        return true;
    }
}