namespace ViewManagerLibrary
{
    /// <summary>
    /// Абстрактный класс объектов для взаимодействия с менеджером окон.
    /// Образует пользовательский интерфейс с возможностью смены окон для создания программ со сложным поведением.
    /// </summary>
    public abstract class View
    {
        public string Id = "none";
    
        /// <summary>
        /// Событие, происходящее при открытии окна
        /// </summary>
        public virtual void OnStart(){}
        
        /// <summary>
        /// Событие происходящее каждую итерацию цикла программы
        /// </summary>
        public virtual void OnIteration(ConsoleKeyInfo key){}
        
        /// <summary>
        /// Событие происходящее при закрытии окна
        /// </summary>
        public virtual void OnClose(){}
    }
}