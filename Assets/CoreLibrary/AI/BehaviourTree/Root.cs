namespace CoreLibrary.AI
{
    /// <summary>
    /// Нод выполняющий все вложенные в него операции 
    /// несмотря на то была ли допущена ошибка при выполнении или нет.
    /// </summary>
    internal class Root : Node
    {
        public Root(string name) : base(name)
        {
        }

        public Root() : base("root node")
        {
        }

        public override Status Process()
        {
            foreach (var child in Children)
            {
                child.Process();
            }

            return Status.Running;
        }
    }
}
