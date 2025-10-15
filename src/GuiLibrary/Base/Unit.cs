namespace GuiLibrary.Base
{
    /// <summary>
    /// Базовый класс, описывающий логику визуального элемента Gui
    /// </summary>
    /// <param name="id">Уникальный идентификатор элемента</param>
    /// <param name="isSelectable">Bool, который показывает возможность выделения элемента</param>
    public abstract class Unit(string id, bool isSelectable = true)
    {
        protected bool IsSelectable = isSelectable;
        public bool IsRendering = true;
        public string Id { get; init; } = id;

        public Action OnUpdate = delegate { };
        public Action OnModify = delegate { };

        /// <summary>
        /// Проверка на то, можно ли выделить элемент
        /// </summary>
        /// <returns>True - если элемент можно выделить, false - если нет</returns>
        public bool CanBeSelected()
        {
            return IsSelectable && IsRendering;
        }

        /// <summary>
        /// Метод комплексного обновления элемента
        /// </summary>
        /// <param name="keyNullable">Данные о клавише, нажатой пользователем</param>
        /// <param name="isSelected">Bool, показывающий выбран ли элемент</param>
        /// <param name="doBreakLine">Bool, показывающий должна ли переноситься строка после вывода элемента</param>
        public virtual void Update(ConsoleKeyInfo? keyNullable = null, bool isSelected = true, bool doBreakLine = true)
        {
            if (!IsRendering)
            {
                return;
            }
            
            ConsoleKeyInfo key = keyNullable ?? new ConsoleKeyInfo();
            
            if (isSelected)
            {
                HandleInput(key);
            }

            if (this is ITitled titled)
            {
                string title = titled.GetTitle();

                if (title.Length > 0)
                {
                    Console.Out.Write(title + titled.GetTitleSeparator());
                }
            }

            OnUpdate?.Invoke();
            
            Draw(isSelected, doBreakLine);
        }
        
        /// <summary>
        /// Обработка взаимодействия элемента с пользователем и реакции на его действия
        /// </summary>
        /// <param name="key">Данные о клавише, нажатой пользователем</param>
        protected abstract void HandleInput(ConsoleKeyInfo key);
        
        /// <summary>
        /// Метод отрисовки элемента
        /// </summary>
        /// <param name="doHighlight">Bool, показывающий то, должен ли элемент быть выделен</param>
        /// <param name="doBreakLine">Bool, показывающий должна ли переноситься строка после вывода элемента</param>
        protected abstract void Draw(bool doHighlight, bool doBreakLine = true);

        /// <summary>
        /// Начать выделение выводимых элементов в консоли
        /// </summary>
        /// <param name="foreground">Цвет текста</param>
        /// <param name="background">Цвет фона</param>
        protected void Highlight(ConsoleColor foreground = Config.DefaultSelectedForegroundColor,
            ConsoleColor background = Config.DefaultSelectedBackgroundColor)
        {
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
        }

        /// <summary>
        /// Установить стандартный стиль консоли
        /// </summary>
        protected void ResetStyle()
        {
            Console.ResetColor();
        }
    }
}