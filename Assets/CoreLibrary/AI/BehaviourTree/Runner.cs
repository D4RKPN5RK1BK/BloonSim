namespace CoreLibrary.AI
{
    /// <summary>
    /// Реализация нода для применения какх либо дествий персонажем
    /// </summary>
    public abstract class Runner : Node
    {
        public abstract void Run();

        public override Status Process()
        {
            Run();
            return Status.Running;
        }
    }
}
