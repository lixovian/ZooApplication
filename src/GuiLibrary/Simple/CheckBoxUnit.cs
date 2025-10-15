using GuiLibrary.Base;

namespace GuiLibrary.Simple
{
    /// <summary>
    /// Элемент, имеющий заголовок и два отображаемых состояния - включенное и выключенное
    /// </summary>
    /// <param name="id">Уникальный идентификатор</param>
    /// <param name="title">Заголовок элемента</param>
    /// <param name="isChosen">Значения включенности по умолчанию</param>
    public class CheckBoxUnit(string id, string title, bool isChosen = false) : Unit(id), ITitled
    {
        private bool _isChosen = isChosen;

        protected override void HandleInput(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.Enter)
            {
                _isChosen = !_isChosen;
                OnModify.Invoke();
            }
        }

        /// <summary>
        /// Узнать, 'включен' ли элемент
        /// </summary>
        /// <returns>True - если включен, false - если нет</returns>
        public bool IsChosen()
        {
            return _isChosen;
        }

        protected override void Draw(bool doHighlight, bool doBreakLine = true)
        {
            if (doHighlight)
            {
                Highlight();
            }
            
            Console.Out.Write(_isChosen ? Config.DefaultCheckMark : Config.DefaultCrossMark);
            
            ResetStyle();

            if (doBreakLine)
            {
                Console.Out.WriteLine();
            }
        }

        public string GetTitle()
        {
            return title;
        }

        public string GetTitleSeparator()
        {
            return " ";
        }
    }
}