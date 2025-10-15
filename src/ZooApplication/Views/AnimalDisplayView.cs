using System.Text;
using AnimalLibrary.Animals;
using DataProcessing.Checking.Filters.Display;
using DataProcessing.Containers;
using DataProcessing.Output;
using GuiLibrary.Assembled;
using GuiLibrary.Base;
using GuiLibrary.Simple;
using Microsoft.Extensions.DependencyInjection;
using ViewManagerLibrary;
using ZooApplication.Service;

namespace ZooApplication.Views;

public class AnimalDisplayView : View
{
    private UnitBlock _block = null!;
    private LabelUnit _label = null!;
    
    public AnimalDisplayView()
    {
        Id = "data_animal";
    }

    public override void OnStart()
    {
        _label = new LabelUnit("main", "");
        
        List<Unit> units =
        [
            new ButtonUnit("back", "Вернуться назад", () => ViewManager.ChangeView("menu")),
            new LabelUnit("title", "Список животных:"), 
            _label
        ];

        _block = new UnitBlock("block", units);
        
        _label.SetLabel(GetData());
        
        _block.Update();
    }

    private string GetData()
    {
        StringBuilder output = new();
        
        var container = Services.Provider.GetService<ObjectData<Animal>>();
        var displayFilter = Services.Provider.GetService<IDisplayFilter<Animal>>();
        var outputFormatter = Services.Provider.GetService<IObjectOutput<Animal>>();

        if (container == null || displayFilter == null || outputFormatter == null)
        {
            return "Нет доступных данных";
        }

        var data = container.GetAll();

        output.AppendLine("---------------");
        foreach (var animal in data)
        {
            if (!displayFilter.Check(animal))
            {
                continue;
            }
            
            output.Append(outputFormatter.Format(animal));
            output.AppendLine("---------------");
        }

        return output.ToString();
    }

    public override void OnIteration(ConsoleKeyInfo key)
    {
        _block.Update(key);
    }
}