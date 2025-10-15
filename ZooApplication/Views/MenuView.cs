using GuiLibrary.Assembled;
using ViewManagerLibrary;

namespace ZooApplication.Views;

/// <summary>
/// Окно, в котором отображается основное меню приложения 
/// </summary>
public class MenuView : View
{
    private ListBlock _menu = null!;

    public MenuView()
    {
        Id = "menu";
    }

    /// <summary>
    /// Метод получения элементов списка действий
    /// </summary>
    /// <returns>Словарь названий элементов меню и соответствующих им действий</returns>
    private static Dictionary<string, Action> GetActions()
    {
        Dictionary<string, Action> output = new()
        {
            { "Добавить новое животное", () => { ViewManager.ChangeView("add_animal"); } },
            { "Добавить элемент в инвентарь", () => { ViewManager.ChangeView("add_inventory"); } },
            { "Получить количество еды для животных", () => { ViewManager.ChangeView("food"); } },
            { "Текущие данные о животных", () => { ViewManager.ChangeView("data_animal"); } },
            { "Текущие данные об инвентаре", () => { ViewManager.ChangeView("data_inventory"); } },
            { "Контактный зоопарк", () => { ViewManager.ChangeView("contact"); } },
            { "Удалить животное из каталога", () => { ViewManager.ChangeView("remove_animal"); } },
            { "Удалить предмет из каталога", () => { ViewManager.ChangeView("remove_item"); } },
            { "Выход", () => { Environment.Exit(0); } }
        };
        return output;
    }

    public override void OnStart()
    {
        _menu = new ListBlock("menu", "Выберите пункт меню:", GetActions());
        _menu.Update();
    }

    public override void OnIteration(ConsoleKeyInfo key)
    {
        _menu.Update(key);
    }
}