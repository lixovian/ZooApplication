namespace GuiLibrary.Base
{
    /// <summary>
    /// Интерфейс для элементов, имеющих заголовок
    /// </summary>
    public interface ITitled
    {
        /// <summary>
        /// Получить заголовок элемента
        /// </summary>
        /// <returns>Строку - заголовок элемента</returns>
        public string GetTitle()
        {
            return "";
        }

        /// <summary>
        /// Получить разделитель между заголовком и телом элемента
        /// </summary>
        /// <returns>Строку - разделитель, стоящий после заголовка</returns>
        public string GetTitleSeparator()
        {
            return Config.DefaultTitleSeparator;
        }
    }
}