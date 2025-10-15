using GuiLibrary.Base;
using GuiLibrary.Simple;

namespace GuiLibrary.Assembled
{
    /// <summary>
    /// Элемент Gui, представляющий собой вертикальный список выбираемых элементов
    /// </summary>
    public class ListBlock : UnitBlock, ITitled
    {
        private readonly string _title;
        
        public ListBlock(string id, string title, Dictionary<string, Action>? taskList = null) : base(id)
        {
            _title = title;

            SetTasks(taskList ?? []);
        }

        /// <summary>
        /// Установить новый список значений для выбора 
        /// </summary>
        /// <param name="taskList">Словарь отображаемых названий значений и соответствующих им действий</param>
        private void SetTasks(Dictionary<string, Action> taskList)
        {
            List<Unit> units = new();
            
            foreach (string key in taskList.Keys)
            {
                units.Add(new ButtonUnit(key, key, taskList[key]));
            }

            SetUnits(units);
        }
        
        public string GetTitle()
        {
            return _title;
        }
        
        public string GetTitleSeparator()
        {
            return Environment.NewLine;
        }
    }
}