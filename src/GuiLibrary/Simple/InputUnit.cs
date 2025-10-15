using GuiLibrary.Base;

namespace GuiLibrary.Simple
{
    /// <summary>
    /// Кастомный элемент Gui для ввода данных с клавиатуры
    /// </summary>
    public class InputUnit : TypeUnit, ITitled
    {
        private readonly string _title;
        
        public InputUnit(string id, string title = "", bool isRendering = true) : base(id)
        {
            _title = title;
            IsRendering = isRendering;
        }
        
        protected override void Draw(bool doHighlight, bool doBreakLine = true)
        {
            if (doHighlight)
            {
                Highlight();
            }
            else
            {
                Highlight(Config.DefaultInputForegroundColor, Config.DefaultInputBackgroundColor);
            }

            // Обрезка данных, если все записанные данные не помещаются в стандартный размер элемента
            string dataVisible = Data.ToString();
            
            if (dataVisible.Length < Config.DefaultInputLength)
            {
                dataVisible = new string(Config.DefaultInputFiller, Config.DefaultInputLength - dataVisible.Length) + dataVisible; 
            }
            else
            {
                dataVisible = dataVisible.Substring(dataVisible.Length - Config.DefaultInputLength, Config.DefaultInputLength);
            }
            
            Console.Out.Write(dataVisible);
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