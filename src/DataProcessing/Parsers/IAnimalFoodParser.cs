using AnimalLibrary.Animals;

namespace DataProcessing.Parsers;

public interface IAnimalFoodParser
{
    public int GetAmount(List<Animal> data)
    {
        return data.Select(x => x.FoodNeeded).Sum();
    }
}