using AnimalLibrary;
using AnimalLibrary.Items.Properties;

namespace DataProcessing.Output.Short;

public class InventoryShortOutput : IObjectShortOutput<IInventory>
{
    public string Format(IInventory obj)
    {
        if (obj is IHasName nameObj)
        {
            return $"{obj.Id}: {nameObj.ItemName} ({obj.Number} штук)";
        }
        
        return $"{obj.Id} ({obj.Number} штук)";
    }
}