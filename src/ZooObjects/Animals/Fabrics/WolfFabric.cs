namespace AnimalLibrary.Animals.Fabrics;

public class WolfFabric : IAnimalFabric
{
    public Animal Create()
    {
        return new Wolf();
    }
}