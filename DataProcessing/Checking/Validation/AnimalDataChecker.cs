using AnimalLibrary.Animals;

namespace DataProcessing.Checking.Validation;

public class AnimalDataChecker : IChecker<Animal>
{
    public bool Check(Animal obj)
    {
        if (obj.Name.Length is 0 or > 100)
        {
            return false;
        }

        if (obj.Age is < 0 or > 100)
        {
            return false;
        }

        if (obj is Herbo { Kindness: < -5 or > 10 })
        {
            return false;
        }

        return true;
    }
}