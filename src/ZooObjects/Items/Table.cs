namespace AnimalLibrary.Items;

public class Table : IInventory
{
    public string GetTypeName() => "Стол";
    
    public Table() {}

    public int Number { get; set; } = 0;
    public string Id { get; set; } = "СТ#000";
}