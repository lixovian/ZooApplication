using AnimalLibrary.Animals;
using ZooObjects.AnimalChecking;

namespace DataValidators;

public class VetClinic
{
    private readonly IChecker<Animal> _healthChecker = new AnimalHealthChecker();

    public bool IsHealthy(Animal animal)
    {
        return _healthChecker.Check(animal);
    }
}