namespace GuiLibrary.Simple.Choosers
{
    /// <summary>
    /// Элемент интерфейса, который позволяет выбирать один из элементов из списка
    /// Все значения отображаются в строку, что делает его размещение более компактным
    /// </summary>
    public class StringChooserUnit : ChooserUnit<string>
    {
        private string[] _values;
        private int _chosenValue;

        public StringChooserUnit(string id, string title, string[]? values = null, bool isRendering = true) : base(id, title, isRendering)
        {
            _values = values ?? [];
        }

        public override void SetValueIndex(int n)
        {
            _chosenValue = n;
        }

        /// <summary>
        /// Отметить значение как текущее
        /// </summary>
        /// <param name="value">Значение задачи, которую нужно отметить как выбранную</param>
        /// <returns>Значение true, если задача поставлена успешно и значение false в ином случае</returns>
        public override bool SetValue(string value)
        {
            for (int i = 0; i < _values.Length; i++)
            {
                if (!_values[i].Equals(value))
                {
                    continue;
                }

                _chosenValue = i;
                return true;
            }

            return false;
        }

        protected override bool AreValuesAvaliable()
        {
            return _values.Length > 0;
        }

        protected override void ChangeValue(bool isMovingForward)
        {
            if (isMovingForward) {
                _chosenValue = (_chosenValue + 1) % _values.Length;
            } else {
                _chosenValue = (_chosenValue - 1 + _values.Length) % _values.Length;
            }
        }
        
        /// <summary>
        /// Привязать к элементу новый набор значений
        /// </summary>
        /// <param name="values">Массив новых значений</param>
        public void SetValues(string[] values)
        {
            _values = values;
            _chosenValue = 0;
        }

        public override string GetCurrentValue()
        {
            return _values.Length <= _chosenValue ? "" : _values[_chosenValue];
        }

        public bool IsEmpty()
        {
            return _values.Length == 0;
        }
        
        public int GetCurrentValueIndex()
        {
            return _chosenValue;
        }

        /// <summary>
        /// Вернуть текущее выбранное значение
        /// </summary>
        /// <returns>Строку, содержащую текущее выбранное значение</returns>
        protected override string GetCurrentDisplay()
        {
            return GetCurrentValue();
        }
    }
}