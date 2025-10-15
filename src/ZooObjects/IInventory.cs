namespace AnimalLibrary;

public interface IInventory
{
    public string GetTypeName();
    public int Number { get; set; }
    public string Id { get; set; }
}