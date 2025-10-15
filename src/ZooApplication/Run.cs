using AnimalLibrary;
using AnimalLibrary.Animals;
using ViewManagerLibrary;
using ZooApplication.Service;
using ZooApplication.Views;

namespace ZooApplication;

class Run()
{
    /// <summary>
    /// Точка входа в программу
    /// </summary>
    public static void Main()
    {
        Services.RegisterDefault();
        
        // Добавляем окна интерфейса
        ViewManager.AddView(new MenuView());
        ViewManager.AddView(new AnimalAddView());
        ViewManager.AddView(new AnimalDisplayView());
        ViewManager.AddView(new FoodView());
        ViewManager.AddView(new InventoryAddView());
        ViewManager.AddView(new InventoryDisplayView());
        ViewManager.AddView(new ContactView());
        ViewManager.AddView(new RemoveView<Animal>("remove_animal"));
        ViewManager.AddView(new RemoveView<IInventory>("remove_item"));
        
        ViewManager.ChangeView("menu");
        ViewManager.SetView();
    }
}