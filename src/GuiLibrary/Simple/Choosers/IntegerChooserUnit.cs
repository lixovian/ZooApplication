namespace GuiLibrary.Simple.Choosers
{
    /// <summary>
    /// Элемент интерфейса, который позволяет выбирать один из элементов из списка
    /// Все значения отображаются в строку, что делает его размещение более компактным
    /// </summary>
    public class IntegerChooserUnit : ChooserUnit<int>
    {
        private readonly int _min;
        private readonly int _max;

        private int _currentValue;

        public IntegerChooserUnit(string id, string title, int minValue, int maxValue, int defaultValue = 0, bool isRendering = true) : base(id, title, isRendering)
        {
            _min = minValue;
            _max = maxValue;
            _currentValue = defaultValue;
        }
        
        public override void SetValueIndex(int n)
        {
            SetValue(n);
        }

        public override bool SetValue(int obj)
        {
            if (obj < _min || obj > _max)
            {
                return  false;
            }

            _currentValue = obj;
            return true;
        }

        protected override bool AreValuesAvaliable()
        {
            return _min <= _max;
        }

        protected override void ChangeValue(bool isMovingForward)
        {
            if (isMovingForward)
            {
                _currentValue += 1;
                if (_currentValue > _max)
                {
                    _currentValue = _max;
                }
            }
            else
            {
                _currentValue -= 1;

                if (_currentValue < _min)
                {
                    _currentValue = _min;
                }
            }
        }

        public override int GetCurrentValue()
        {
            return _currentValue;
        }

        protected override string GetCurrentDisplay()
        {
            return GetCurrentValue().ToString();
        }
    }
}