namespace CoreLibrary.AI
{
    /// <summary>
    /// <para>Стандартная реализация нода.</para>
    /// <para>Внутренние ноды выполняются до тех пор пока один из них не завершиться успешно</para>
    /// </summary>
    public class Selector : Node
    {
        public Selector(string name) : base(name)
        {
        }

        public Selector() : base("selector")
        {
        }

        public override Status Process()
        {
            foreach (var child in Children)
            {
                var status = child.Process();

                switch (status)
                {
                    case Status.Success:
                    case Status.Running:
                        return status;
                    case Status.Failed:
                    default: 
                        continue;
                }
            }

            return Status.Failed;
        }
    }
}