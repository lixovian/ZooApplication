using GuiLibrary.Base;

namespace GuiLibrary.Simple
{
    /// <summary>
    /// Элемент стандартной кнопки. Выполняет действие при нажатии
    /// </summary>
    public class ButtonUnit : Unit
    {
        private readonly string _label;
        private readonly Action _onClick;
        
        public ButtonUnit(string id, string label, Action onClick, bool isRendering = true) : base(id)
        {
            _label = label;
            _onClick = onClick;
            
            IsRendering = isRendering;
        }
        
        protected override void HandleInput(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.Enter)
            {
                _onClick();
                OnModify.Invoke();
            }
        }   

        protected override void Draw(bool doHighlight, bool doBreakLine = true)
        {
            if (doHighlight)
            {
                Highlight();
            }
            else
            {
                Highlight(Config.DefaultButtonForegroundColor, Config.DefaultButtonBackgroundColor);
            }
            
            Console.Out.Write(_label);

            if (doBreakLine)
            {
                Console.Out.WriteLine();
            }
            
            ResetStyle();
        }
    }
}