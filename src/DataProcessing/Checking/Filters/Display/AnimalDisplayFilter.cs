using AnimalLibrary.Animals;

namespace DataProcessing.Checking.Filters.Display;

public class AnimalDisplayFilter : IDisplayFilter<Animal>
{
    public bool Check(Animal obj)
    {
        return true;
    }
}