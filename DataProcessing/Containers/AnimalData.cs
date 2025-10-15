using AnimalLibrary.Animals;
using DataProcessing.Checking;
using DataProcessing.Checking.Validation;

namespace DataProcessing.Containers;

public class AnimalData : ObjectData<Animal>
{
    private readonly IChecker<Animal> _validChecker = new AnimalDataChecker();
    private readonly IChecker<Animal> _healthChecker = new VetClinicHealthChecker();

    protected override bool IsDataValid(Animal obj)
    {
        if (!_validChecker.Check(obj))
        {
            throw new InvalidDataException();
        }
        
        if (!_healthChecker.Check(obj))
        {
            return false;
        }
        
        return true;
    }
}