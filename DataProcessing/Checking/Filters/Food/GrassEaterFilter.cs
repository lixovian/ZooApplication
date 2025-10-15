using AnimalLibrary.Animals;

namespace DataProcessing.Checking.Filters.Food;

public class GrassEaterFilter : IGrassEaterFilter
{
    public bool Check(Animal obj)
    {
        return obj is Herbo;
    }
}