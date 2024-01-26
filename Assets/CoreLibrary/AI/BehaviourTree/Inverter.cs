namespace CoreLibrary.AI
{
    /// <summary>
    /// Инвертирует вложенный нод
    /// </summary>
    internal class Inverter : Node
    {
        private readonly INode _target;

        public Inverter(INode target) : base("inverter")
        {
            _target = target;
        }

        public override Status Process()
        {
            var result = _target.Process();

            switch (result)
            {
                case Status.Success: 
                case Status.Running: 
                    return Status.Failed;
                case Status.Failed:
                default: 
                    return Status.Success;
            }
        }
    }
}
