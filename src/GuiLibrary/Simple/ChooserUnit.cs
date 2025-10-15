using GuiLibrary.Base;
using ConsoleKey = System.ConsoleKey;

namespace GuiLibrary.Simple
{
    /// <summary>
    /// Элемент интерфейса, который позволяет выбирать один из элементов из списка
    /// Все значения отображаются в строку, что делает его размещение более компактным
    /// </summary>
    public abstract class ChooserUnit<T> : Unit, ITitled
    {
        private string _title;

        public abstract T GetCurrentValue();
        protected abstract string GetCurrentDisplay();

        public abstract void SetValueIndex(int n);
        public abstract bool SetValue(T obj);

        protected abstract bool AreValuesAvaliable();

        protected abstract void ChangeValue(bool isMovingForward);

        protected ChooserUnit(string id, string title, bool isRendering = true) : base(id)
        {
            _title = title;
            IsRendering = isRendering;
        }
        
        protected override void HandleInput(ConsoleKeyInfo key)
        {
            if (!AreValuesAvaliable())
            {
                return;
            }
            
            // Тут явно не нужно использовать вместо Default спецификацию со всеми клавишами клавиатуры...
            // ReSharper disable once SwitchStatementHandlesSomeKnownEnumValuesWithDefault
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    ChangeValue(false);
                    break;
                case ConsoleKey.RightArrow:
                    ChangeValue(true);
                    break;
                default:
                    return;
            }

            OnModify.Invoke();
        }

        protected override void Draw(bool doHighlight, bool doBreakLine = true)
        {
            if (doHighlight)
            {
                Highlight();
            }

            Console.Out.Write($"<- {GetCurrentDisplay()} ->");

            ResetStyle();

            if (doBreakLine)
            {
                Console.Out.WriteLine();
            }
        }

        public string GetTitle()
        {
            return _title;
        }
    }
}