namespace CoreLibrary.AI
{
    /// <summary>
    /// <para>Стандартная реализация нода.</para> 
    /// <para>Внутренние ноды будут выполнятся последоватьельно пока не наткнутся на Faild результат нода.</para> 
    /// <para>Если хотябы один из внутренних нодов в настоящий момент имеет статус Runnning, то статус данного нода будет соответствующим.</para> 
    /// </summary>
    public class Sequence : Node
    {
        public Sequence(string name) : base(name)
        {
        }

        public Sequence() : base("sequence")
        {
        }

        public override Status Process()
        {
            bool anyChildIsRunning = false;
            
            foreach (var child in Children)
            {
                var status = child.Process();

                switch (status)
                {
                    case Status.Success:
                        continue;
                    case Status.Running:
                        anyChildIsRunning = true;
                        continue;
                    case Status.Failed:
                    default: 
                        return status;
                }
            }

            return anyChildIsRunning ? Status.Running : Status.Success;
        }
    }
}