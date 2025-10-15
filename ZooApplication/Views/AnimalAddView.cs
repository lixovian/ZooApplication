using AnimalLibrary.Animals;
using AnimalLibrary.Animals.Fabrics;
using DataProcessing.Containers;
using DataProcessing.Create;
using GuiLibrary.Assembled;
using GuiLibrary.Base;
using GuiLibrary.Simple;
using GuiLibrary.Simple.Choosers;
using Microsoft.Extensions.DependencyInjection;
using ViewManagerLibrary;
using ZooApplication.Service;

namespace ZooApplication.Views
{
    /// <summary>
    /// Окно добавления данных о животных
    /// </summary>
    public class AnimalAddView : View
    {
        private UnitBlock _block = null!;

        private InputUnit _nameInput = null!;
        private StringChooserUnit _typeChooser = null!;
        private CheckBoxUnit _checkNeuteredUnit = null!;
        private IntegerChooserUnit _foodChooser = null!;
        private IntegerChooserUnit _ageChooser = null!;
        private IntegerChooserUnit _kindChooser = null!;
        private LabelUnit _label = null!;

        public AnimalAddView()
        {
            Id = "add_animal";
        }

        /// <summary>
        /// Метод добавления данных о животных в каталог
        /// </summary>
        private void Add()
        {
            string type = _typeChooser.GetCurrentValue();

            var creator = Services.Provider.GetService<ObjectCreator<IAnimalFabric>>();
            if (creator == null)
            {
                return;
            }

            Animal created = creator.GetCreator(type).Create();

            created.Name = _nameInput.GetData();
            created.FoodNeeded = _foodChooser.GetCurrentValue();
            created.Age = _ageChooser.GetCurrentValue();
            created.IsNeutered = _checkNeuteredUnit.IsChosen();

            if (created is Herbo herbo)
            {
                herbo.Kindness = _kindChooser.GetCurrentValue();
                created = herbo;
            }

            try
            {
                var container = Services.Provider.GetService<ObjectData<Animal>>();
                if (container == null)
                {
                    return;
                }

                _label.SetLabel(container.Add(created)
                    ? "--Животное добавлено успешно--"
                    : "--Животное не подходит по состоянию здоровья--");
            }
            catch (InvalidDataException)
            {
                _label.SetLabel("--Данные о животном неверные--");
            }
        }

        public override void OnStart()
        {
            var creator = Services.Provider.GetService<ObjectCreator<IAnimalFabric>>();

            string[] names = [];
            if (creator != null)
            {
                names = creator.GetNames();
            }

            _nameInput = new InputUnit("name", "Имя");
            _typeChooser = new StringChooserUnit("type", "Выберите род животного", names);
            _checkNeuteredUnit = new CheckBoxUnit("neutered", "Кастрировано", true);
            _foodChooser = new IntegerChooserUnit("food", "Выберите количество еды в день (в кг)", 1, 25, 5, true);
            _ageChooser = new IntegerChooserUnit("age", "Выберите возраст", 0, 100, 1, true);
            _kindChooser = new IntegerChooserUnit("kindness", "Выберите степень доброты", -5, 10, 0, false);
            _label = new LabelUnit("condition", "--Ожидание добавления--");

            List<Unit> units =
            [
                new LabelUnit("label", "Введите данные о животном:"),
                _typeChooser,
                _nameInput,
                _checkNeuteredUnit,
                _foodChooser,
                _ageChooser,
                _kindChooser,
                new UnitBlock("buttons", new Unit[]
                {
                    new ButtonUnit("add", "Добавить животное", Add),
                    new ButtonUnit("back", "Вернуться назад", () => ViewManager.ChangeView("menu"))
                }, true),
                _label
            ];

            _block = new UnitBlock("block", units);

            _typeChooser.OnUpdate = () =>
            {
                var c = Services.Provider.GetService<ObjectCreator<IAnimalFabric>>();
                if (c == null)
                {
                    return;
                }
                Animal temp = c.GetCreator(_typeChooser.GetCurrentValue()).Create();
                _kindChooser.IsRendering = temp is Herbo;
            };

            _block.Update();
        }

        public override void OnIteration(ConsoleKeyInfo key)
        {
            _label.SetLabel("--Ожидание добавления--");
            _block.Update(key);
        }
    }
}