using GuiLibrary.Base;

namespace GuiLibrary.Assembled
{
    /// <summary>
    /// Сложный элемент Gui, который представляет собой несколько других соединенных элементов Gui
    /// </summary>
    public class UnitBlock : Unit
    {
        private List<Unit> _units = null!;
        private int _currentIndex;
        
        private readonly bool _isHorizontal;

        public UnitBlock(string id, Unit[]? units = null, bool isHorizontal = false) : base(id)
        {
            _isHorizontal = isHorizontal;
            
            SetUnits(units ?? []);
        }

        public UnitBlock(string id, List<Unit> units, bool isHorizontal = false) : base(id)
        {
            _isHorizontal = isHorizontal;
            
            SetUnits(units);
        }

        /// <summary>
        /// Установить значения элементов, из которых состоит блок
        /// </summary>
        /// <param name="units">Массив значений элементов</param>
        private void SetUnits(Unit[] units)
        {
            SetUnits(units.ToList());
        }

        /// <summary>
        /// Установить значения элементов, из которых состоит блок
        /// </summary>
        /// <param name="units">Список значений элементов</param>
        protected void SetUnits(List<Unit> units)
        {
            _units = units;

            _currentIndex = _units.Count - 1;
            MoveArrow(false);
        }

        /// <summary>
        /// Получить значения элементов, из которых состоит блок
        /// </summary>
        /// <returns>Список элементов, из которых состоит элемент</returns>
        public List<Unit> GetUnits()
        {
            return _units;
        }

        /// <summary>
        /// Получить текущий выбранный элемент
        /// </summary>
        /// <returns>Элемент, выбранный в текущий момент</returns>
        public Unit GetCurrentUnit()
        {
            return _units[_currentIndex];
        }
        
        /// <summary>
        /// Получить элемент блока по его идентификатору
        /// </summary>
        /// <param name="id">Уникальный идентификатор элемента</param>
        /// <returns>Элемент, соответствующий идентификатору, или null</returns>
        public Unit? GetUnit(string id)
        {
            return _units.FirstOrDefault(unit => unit.Id == id);
        }
        
        protected override void HandleInput(ConsoleKeyInfo key)
        {
            if (_isHorizontal)
            {
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        MoveArrow(true);
                        break;
                    case ConsoleKey.RightArrow:
                        MoveArrow(false);
                        break;
                    default:
                        return;
                }
            }
            else
            {
                // Тут явно не нужно использовать вместо Default спецификацию со всеми клавишами клавиатуры...
                // ReSharper disable once SwitchStatementHandlesSomeKnownEnumValuesWithDefault
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        MoveArrow(true);
                        break;
                    case ConsoleKey.DownArrow:
                        MoveArrow(false);
                        break;
                    default:
                        return;
                }
            }

            OnModify.Invoke();
        }

        /// <summary>
        /// Метод обработки ввода для перемещения по элементам блока
        /// </summary>
        /// <param name="isMovingUpwards"></param>
        private void MoveArrow(bool isMovingUpwards)
        {
            if (_units.Count == 0)
            {
                return;
            }

            int newIndex = _currentIndex;
            do
            {
                newIndex += isMovingUpwards ? -1 : 1;

                if (newIndex < 0)
                {
                    newIndex = _units.Count - 1;
                } else if (newIndex >= _units.Count)
                {
                    newIndex = 0;
                }
                
            } while (!_units[newIndex].CanBeSelected() && newIndex != _currentIndex);

            _currentIndex = newIndex;
        }

        protected override void Draw(bool doHighlight, bool doBreakLine = true) { }

        public override void Update(ConsoleKeyInfo? keyNullable = null, bool isSelected = true, bool doBreakLine = true)
        {
            base.Update(keyNullable, isSelected, doBreakLine);
            
            for (int i = 0; i < _units.Count; i++)
            {
                Unit unit = _units[i];
                unit.Update(keyNullable, _currentIndex == i && isSelected, !_isHorizontal || i == _units.Count - 1);

                if (_isHorizontal && i < _units.Count - 1)
                {
                    Console.Out.Write(Config.DefaultHorizontalBlockSeparator);
                }
            }
        }
    }
}