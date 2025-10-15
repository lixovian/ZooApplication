using System.Text;

namespace GuiLibrary.Base
{
    /// <summary>
    /// Абстрактный класс для создания логики взаимодействия для объектов с возможностью ввода данных с клавиатуры
    /// </summary>
    /// <param name="id">Уникальный идентификатор элемента</param>
    public abstract class TypeUnit(string id) : Unit(id)
    {
        protected readonly StringBuilder Data = new("");

        protected override void HandleInput(ConsoleKeyInfo keyData)
        {
            char keyChar = keyData.KeyChar;
            ConsoleKey key = keyData.Key;

            if (key == ConsoleKey.Backspace)
            {
                if (Data.Length > 0)
                {
                    Data.Length--;
                    OnModify.Invoke();
                }
            }
            else if ((char.IsLetterOrDigit(keyChar) || char.IsAscii(keyChar)) && !IsNonPrintableAsciiCharacter(keyChar))
            {
                Data.Append(keyChar);
                OnModify.Invoke();
            }
        }

        /// <summary>
        /// Проверка на то, что символ не является служебным
        /// Данные взяты из https://theasciicode.com.ar/
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private static bool IsNonPrintableAsciiCharacter(char c)
        {
            return (c >= 0 && c <= 31) || c == 127;
        }

        /// <summary>
        /// Установить новое значение в буфер данных элемента
        /// </summary>
        /// <param name="newData">Новое значение буфера</param>
        public void SetData(string newData)
        {
            Data.Clear();
            Data.Append(newData);
        }

        /// <summary>
        /// Получить записанные в элемент данные
        /// </summary>
        /// <returns>Строковый эквивалент записанных в буфер данных</returns>
        public string GetData()
        {
            return Data.ToString();
        }
    }
}