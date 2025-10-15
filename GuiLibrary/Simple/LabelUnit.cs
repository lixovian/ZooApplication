using GuiLibrary.Base;

namespace GuiLibrary.Simple
{
    /// <summary>
    /// Элемент Gui, который представляет собой обычную надпись (строку) 
    /// </summary>
    public class LabelUnit : Unit
    {
        private string _label;

        public LabelUnit(string id, string label, bool isRendering = true, bool isSelectable = false) : base(id)
        {
            _label = label;
            IsSelectable = isSelectable;
            IsRendering = isRendering;
        }

        /// <summary>
        /// Установить значение строки для отображения
        /// </summary>
        /// <param name="newLabel">Новое отображаемое значение</param>
        public void SetLabel(string newLabel)
        {
            _label = newLabel;
        }

        protected override void HandleInput(ConsoleKeyInfo key) { }

        protected override void Draw(bool doHighlight, bool doBreakLine = true)
        {
            if (doHighlight)
            {
                Highlight();
            }

            Console.Out.Write(_label);
            ResetStyle();

            if (doBreakLine)
            {
                Console.Out.WriteLine();
            }
        }
    }
}