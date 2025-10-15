using AnimalLibrary.Animals;

namespace DataProcessing.Parsers;

public class AnimalFoodParser : IAnimalFoodParser
{
    public int GetAmount(List<Animal> data)
    {
        if (data == null)
        {
            throw new ArgumentNullException(nameof(data));
        }
        
        return data.Select(x => x.FoodNeeded).Sum();
    }
}