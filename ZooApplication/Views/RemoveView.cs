using DataProcessing.Containers;
using DataProcessing.Output.Short;
using GuiLibrary.Assembled;
using GuiLibrary.Base;
using GuiLibrary.Simple;
using GuiLibrary.Simple.Choosers;
using Microsoft.Extensions.DependencyInjection;
using ViewManagerLibrary;
using ZooApplication.Service;

namespace ZooApplication.Views;

public class RemoveView<T> : View
{
    private UnitBlock _major = null!;
    private StringChooserUnit _chooser = null!;
    private bool _shouldBeUpdated;

    public RemoveView(string id)
    {
        Id = id;
    }

    /// <summary>
    /// Метод пересоздания основного блока элементов
    /// </summary>
    private void UpdateChooser()
    {
        var container = Services.Provider.GetService<ObjectData<T>>();
        var formatter = Services.Provider.GetService<IObjectShortOutput<T>>();

        if (container == null || formatter == null)
        {
            return;
        }

        string[] captions = container.GetAll().Select(formatter.Format).ToArray();
        _chooser.SetValues(captions);

        _shouldBeUpdated = true;
    }

    private void Delete()
    {
        if (_chooser.IsEmpty())
        {
            return;
        }

        var container = Services.Provider.GetService<ObjectData<T>>();

        if (container == null)
        {
            return;
        }

        container.Remove(container.At(_chooser.GetCurrentValueIndex()));
        UpdateChooser();
    }

    public override void OnStart()
    {
        _chooser = new StringChooserUnit("choose", "");
        UpdateChooser();

        _major = new UnitBlock("major", new Unit[]
        {
            new LabelUnit("title", "Удалить элементы:"),
            _chooser,
            new UnitBlock("buttons", new Unit[]
            {
                new ButtonUnit("remove", "Удалить", Delete),
                new ButtonUnit("back", "Вернуться назад", () => ViewManager.ChangeView("menu"))
            }, true)
        });

        _major.Update();
    }

    public override void OnIteration(ConsoleKeyInfo key)
    {
        _major.Update(key);

        if (!_shouldBeUpdated)
        {
            return;
        }

        Console.Clear();
        _major.Update();

        _shouldBeUpdated = false;
    }
}