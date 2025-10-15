using AnimalLibrary;
using AnimalLibrary.Animals;
using DataValidators.DataValidators;
using ZooObjects.AnimalChecking;

namespace DataValidators;

public class Zoo
{
    private readonly IChecker<IInventory> _itemChecker = new InventoryDataChecker();
    private readonly IChecker<Animal> _animalChecker = new AnimalDataChecker();

    public bool CheckItem(IInventory item)
    {
        return _itemChecker.Check(item);
    }

    public bool CheckAnimal(Animal animal)
    {
        return _animalChecker.Check(animal);
    }
}