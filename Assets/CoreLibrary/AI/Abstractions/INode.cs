namespace CoreLibrary.AI
{
    /// <summary>
    /// Нод для реализации древа поведений персонажа
    /// </summary>
    public interface INode
    {
        /// <summary>
        /// Обработка логики поведения персонажа
        /// </summary>
        /// <returns></returns>
        Status Process();
    }
}