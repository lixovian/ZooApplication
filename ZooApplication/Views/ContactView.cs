using System.Text;
using AnimalLibrary.Animals;
using DataProcessing.Checking.Filters.Contact;
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

public class ContactView : View
{
    private UnitBlock _block;
    private LabelUnit _label;
    
    public ContactView()
    {
        Id = "contact";
    }

    public override void OnStart()
    {
        List<Unit> units =
        [
            new ButtonUnit("back", "Вернуться назад", () => ViewManager.ChangeView("menu")),
            new LabelUnit("title", "Животные, которые могут содержаться в контактном зоопарке:"), 
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
        var contactFilter = Services.Provider.GetService<IContactFilter>();
        var outputFormatter = Services.Provider.GetService<IObjectOutput<Animal>>();

        if (container == null || displayFilter == null || contactFilter == null || outputFormatter == null)
        {
            return "Нет доступных данных";
        }

        var data = container.GetAll();

        foreach (var animal in data)
        {
            if (!displayFilter.Check(animal) || !contactFilter.Check(animal))
            {
                continue;
            }
            
            output.AppendLine(outputFormatter.Format(animal));
        }
        
        return output.ToString();
    }

    public override void OnIteration(ConsoleKeyInfo key)
    {
        _block.Update(key);
    }
}