namespace AnimalLibrary.Animals.Fabrics;

public class RabbitFabric : IAnimalFabric
{
    public Animal Create()
    {
        return new Rabbit();
    }
}