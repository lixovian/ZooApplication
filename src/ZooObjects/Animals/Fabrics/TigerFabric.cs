namespace AnimalLibrary.Animals.Fabrics;

public class TigerFabric : IAnimalFabric
{
    public Animal Create()
    {
        return new Tiger();
    }
}