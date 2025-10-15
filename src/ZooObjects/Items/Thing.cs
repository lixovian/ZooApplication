using AnimalLibrary.Items.Properties;

namespace AnimalLibrary.Items;

public class Thing : IInventory, IHasName
{
    public string GetTypeName() => "Предмет";

    public string ItemName { get; set; } = "";
    public int Number { get; set; } = 0;
    public string Id { get; set; } = "ПР#000";

    public Thing() {}
}