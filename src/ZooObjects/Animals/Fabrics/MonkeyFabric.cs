namespace AnimalLibrary.Animals.Fabrics;

public class MonkeyFabric : IAnimalFabric
{
    public Animal Create()
    {
        return new Monkey();
    }
}