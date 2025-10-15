using AnimalLibrary;
using AnimalLibrary.Items.Fabrics;
using AnimalLibrary.Items.Properties;
using DataProcessing.Containers;
using DataProcessing.Create;
using GuiLibrary.Assembled;
using GuiLibrary.Base;
using GuiLibrary.Simple;
using GuiLibrary.Simple.Choosers;
using Microsoft.Extensions.DependencyInjection;
using ViewManagerLibrary;
using ZooApplication.Service;

namespace ZooApplication.Views;

public class InventoryAddView : View
{
    private UnitBlock _block;

    private StringChooserUnit _typeChooser;
    private InputUnit _nameInput;
    private InputUnit _idInput;
    private IntegerChooserUnit _numberChooser;
    private InputUnit _monitorInput;

    private LabelUnit _label;


    public InventoryAddView()
    {
        Id = "add_inventory";
    }

    private void AddInventory()
    {
        string type = _typeChooser.GetCurrentValue();

        var creator = Services.Provider.GetService<ObjectCreator<IInventoryFabric>>();
        if (creator == null)
        {
            return;
        }

        IInventory created = creator.GetCreator(type).Create();

        created.Id = _idInput.GetData();
        created.Number = _numberChooser.GetCurrentValue();

        if (created is IHasName name)
        {
            name.ItemName = _nameInput.GetData();
        }

        if (created is IHasMonitor monitor)
        {
            monitor.MonitorModel = _monitorInput.GetData();
        }
        
        try
        {
            var container = Services.Provider.GetService<ObjectData<IInventory>>();
            if (container == null)
            {
                return;
            }

            _label.SetLabel(container.Add(created)
                ? "--Предмет добавлен успешно--"
                : "--Ошибка! Предмет не был добавлен--");
        }
        catch (InvalidDataException)
        {
            _label.SetLabel("--Неправильный формат данных--");
        }
    }

    public override void OnStart()
    {
        var creator = Services.Provider.GetService<ObjectCreator<IInventoryFabric>>();
        string[] names = [];
        if (creator != null)
        {
            names = creator.GetNames();
        }

        _typeChooser = new StringChooserUnit("type", "Выберите тип предмета: ", names);
        _nameInput = new InputUnit("name", "Название предмета");
        _idInput = new InputUnit("id", "ID (AB#123)");
        _numberChooser = new IntegerChooserUnit("number", "Количество", 1, 1000, 1, true);
        _monitorInput = new InputUnit("monitor", "Модель монитора");

        _label = new LabelUnit("condition", "--Ожидание добавления--");

        List<Unit> units =
        [
            new LabelUnit("label", "Введите данные о предмете:"),
            _typeChooser,
            _idInput,
            _nameInput,
            _numberChooser,
            _monitorInput,
            new UnitBlock("buttons", new Unit[]
            {
                new ButtonUnit("add", "Добавить предмет", AddInventory),
                new ButtonUnit("back", "Вернуться назад", () => ViewManager.ChangeView("menu"))
            }, true),
            _label
        ];

        _block = new UnitBlock("block", units);

        _typeChooser.OnUpdate = () =>
        {
            var c = Services.Provider.GetService<ObjectCreator<IInventoryFabric>>();
            if (c == null)
            {
                return;
            }

            IInventory temp = c.GetCreator(_typeChooser.GetCurrentValue()).Create();

            _monitorInput.IsRendering = temp is IHasMonitor;
            _nameInput.IsRendering = temp is IHasName;
        };

        _block.Update();
    }

    public override void OnIteration(ConsoleKeyInfo key)
    {
        _label.SetLabel("--Ожидание добавления--");
        _block.Update(key);
    }
}