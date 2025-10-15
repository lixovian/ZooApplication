using AnimalLibrary.Animals;

namespace DataProcessing.Output.Short;

public class AnimalShortOutput : IObjectShortOutput<Animal>
{
    public string Format(Animal obj)
    {
        return $"{obj.GetTypeName()} {obj.Name} ({obj.Age} лет)";
    }
}