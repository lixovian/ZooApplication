namespace ViewManagerLibrary
{
    /// <summary>
    /// Менеджер окон
    /// </summary>
    public static class ViewManager
    {
        private static readonly List<View> Views = [];
    
        private static int _currentView;
        private static bool _isInterrupted;

        /// <summary>
        /// Добавить 
        /// </summary>
        /// <param name="view"></param>
        public static void AddView(View view)
        {
            Views.Add(view);
        }

        /// <summary>
        /// Поставить выбранное окно в качестве текущего запущенного
        /// </summary>
        public static void SetView()
        {
            // Цикл бесконечного повтора решения
            
            while (true)
            {
                View currentView = Views[_currentView];

                Console.Clear();

                currentView.OnStart();

                _isInterrupted = false;
                while (!_isInterrupted)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    Console.Clear();
                    currentView.OnIteration(key);
                }

                currentView.OnClose();
            }
            // ReSharper disable once FunctionNeverReturns
        }

        /// <summary>
        /// Получить окно по id
        /// </summary>
        /// <param name="id">Идентификатор окон, хранящийся в них</param>
        /// <returns>Экземпляр окна или null, если окна с таким id нет</returns>
        public static View? GetView(string id)
        {
            return Views.FirstOrDefault(view => view.Id == id);
        }

        /// <summary>
        /// Изменить текущее окно на другое
        /// </summary>
        /// <param name="n">Номер окна для замены</param>
        private static void ChangeView(int n)
        {
            _currentView = n;
            _isInterrupted = true;
        }

        /// <summary>
        /// Изменить текущее окно на другое
        /// </summary>
        /// <param name="id">Идентификатор окна для замены</param>
        public static void ChangeView(string id)
        {
            for (int i = 0; i < Views.Count; i++)
            {
                View view = Views[i];
                if (view.Id != id)
                {
                    continue;
                }

                ChangeView(i);
                return;
            }
        }
    }
}