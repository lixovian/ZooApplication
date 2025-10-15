namespace AnimalLibrary.Animals;

public abstract class Animal : IAlive
{
    public virtual string GetTypeName() => "Animal";
    public string Name { get; set; } = "";
    public int Age { get; set; } = 0;
    public bool IsNeutered { get; set; } = false;
    public int FoodNeeded { get; set; } = 0;
}