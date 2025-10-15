using System.Text;
using AnimalLibrary.Animals;
using DataProcessing.Checking.Filters.Food;
using DataProcessing.Containers;
using DataProcessing.Parsers;
using GuiLibrary.Assembled;
using GuiLibrary.Base;
using GuiLibrary.Simple;
using Microsoft.Extensions.DependencyInjection;
using ViewManagerLibrary;
using ZooApplication.Service;

namespace ZooApplication.Views;

public class FoodView : View
{
    private UnitBlock _block = null!;
    private LabelUnit _label = null!;
    
    public FoodView()
    {
        Id = "food";
    }

    public override void OnStart()
    {
        _label = new LabelUnit("main", "");
        List<Unit> units =
        [
            new ButtonUnit("back", "Вернуться назад", () => ViewManager.ChangeView("menu")),
            new LabelUnit("title", "Количество еды, необходимое животным:"), 
            _label
        ];

        _block = new UnitBlock("block", units);
        
        _label.SetLabel(GetData());
        
        _block.Update();
    }

    private string GetData()
    {
        var container = Services.Provider.GetService<ObjectData<Animal>>();
        var parser = Services.Provider.GetService<IAnimalFoodParser>();
        
        var grassFilter = Services.Provider.GetService<IGrassEaterFilter>();
        var meatFilter = Services.Provider.GetService<IMeatEaterFilter>();

        if (container == null || parser == null || grassFilter == null || meatFilter == null)
        {
            return "Данные не были получены";
        }

        int grass = parser.GetAmount(container.GetFilterData(grassFilter));
        int meat = parser.GetAmount(container.GetFilterData(meatFilter));

        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Всего необходимо {meat + grass} кг корма в день");
        sb.AppendLine($"Травоядного корма необходимо {grass} кг");
        sb.AppendLine($"Мяса необходимо {meat} кг");
        
        return sb.ToString();
    }

    public override void OnIteration(ConsoleKeyInfo key)
    {
        _block.Update(key);
    }
}