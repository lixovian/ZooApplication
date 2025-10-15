using AnimalLibrary.Items.Properties;

namespace AnimalLibrary.Items;

public class Computer : IInventory, IHasMonitor
{
    public string GetTypeName() => "Компьютер";

    public int Number { get; set; } = 0;
    public string Id { get; set; } = "КП#000";

    public string MonitorModel { get; set; }
    
    public Computer() {}
}