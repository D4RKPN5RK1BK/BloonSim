namespace CoreLibrary.AI
{
    /// <summary>
    /// Реализация нода для проверки
    /// </summary>
    public abstract class Checker : Node
    {
        public abstract bool Check();

        public override Status Process()
        {
            return Check()
                ? Status.Success
                : Status.Failed;
        }
    }
}
