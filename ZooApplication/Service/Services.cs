using AnimalLibrary;
using AnimalLibrary.Animals;
using AnimalLibrary.Animals.Fabrics;
using AnimalLibrary.Items.Fabrics;
using DataProcessing.Checking.Filters.Contact;
using DataProcessing.Checking.Filters.Display;
using DataProcessing.Checking.Filters.Food;
using DataProcessing.Containers;
using DataProcessing.Create;
using DataProcessing.Output;
using DataProcessing.Output.Short;
using DataProcessing.Parsers;
using Microsoft.Extensions.DependencyInjection;

namespace ZooApplication.Service;


public static class Services
{
    public static IServiceProvider Provider = null!;

    public static void RegisterDefault()
    {
        IServiceCollection collection = new ServiceCollection();

        collection.AddSingleton<ObjectData<Animal>, AnimalData>();
        collection.AddSingleton<ObjectData<IInventory>, InventoryData>();
        
        collection.AddSingleton<ObjectCreator<IAnimalFabric>, AnimalCreator>();
        collection.AddSingleton<ObjectCreator<IInventoryFabric>, InventoryCreator>();
        
        collection.AddSingleton<IObjectOutput<Animal>, AnimalOutput>();
        collection.AddSingleton<IObjectOutput<IInventory>, InventoryOutput>();  
        
        collection.AddSingleton<IContactFilter, ContactFilter>();
        collection.AddSingleton<IAnimalFoodParser, AnimalFoodParser>();
        
        collection.AddSingleton<IGrassEaterFilter, GrassEaterFilter>();
        collection.AddSingleton<IMeatEaterFilter, MeatEaterFilter>();
        
        collection.AddSingleton<IObjectShortOutput<Animal>, AnimalShortOutput>();
        collection.AddSingleton<IObjectShortOutput<IInventory>, InventoryShortOutput>();
        
        collection.AddSingleton<IDisplayFilter<Animal>, AnimalDisplayFilter>();  
        collection.AddSingleton<IDisplayFilter<IInventory>, InventoryDisplayFilter>();  

        Provider = collection.BuildServiceProvider();
    }
    
}