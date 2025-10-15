using AnimalLibrary.Animals.Fabrics;

namespace DataProcessing.Create;

public class AnimalCreator : ObjectCreator<IAnimalFabric>
{
    private readonly Dictionary<string, IAnimalFabric> _types = new()
    {
        {"Обезьяна", new MonkeyFabric()},
        {"Кролик", new RabbitFabric()},
        {"Тигр", new TigerFabric()},
        {"Волк", new WolfFabric()},
    };
    
    protected override Dictionary<string, IAnimalFabric> GetTypes()
    {
        return _types;
    }

    public override string[] GetNames()
    {
        return _types.Keys.ToArray();
    }
}