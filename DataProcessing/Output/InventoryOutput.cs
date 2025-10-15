using System.Text;
using AnimalLibrary;
using AnimalLibrary.Items.Properties;

namespace DataProcessing.Output;

public class InventoryOutput : IObjectOutput<IInventory>
{
    public string Format(IInventory obj)
    {
        StringBuilder sb = new();

        sb.AppendLine($"{obj.GetTypeName()} - {obj.Id} ({obj.Number} штук)");

        if (obj is IHasName n)
        {
            sb.AppendLine($"Название {n.ItemName}");
        }

        if (obj is IHasMonitor m)
        {
            sb.AppendLine($"Модель монитора {m.MonitorModel}");
        }

        return sb.ToString();
    }
}