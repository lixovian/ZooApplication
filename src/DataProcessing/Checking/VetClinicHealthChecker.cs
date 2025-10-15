using AnimalLibrary.Animals;

namespace DataProcessing.Checking;

public class VetClinicHealthChecker : IChecker<Animal>
{
    public bool Check(Animal obj)
    {
        if (obj == null)
        {
            throw new ArgumentNullException(nameof(obj));
        }
        
        if (obj.Age > 50)
        {
            return false;
        }
        
        if (obj is Herbo { Kindness: < 0 })
        {
            return false;
        }

        return true;
    }
}