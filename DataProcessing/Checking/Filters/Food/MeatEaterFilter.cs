using AnimalLibrary.Animals;

namespace DataProcessing.Checking.Filters.Food;

public class MeatEaterFilter : IMeatEaterFilter
{
    public bool Check(Animal obj)
    {
        return obj is Predator;
    }
}