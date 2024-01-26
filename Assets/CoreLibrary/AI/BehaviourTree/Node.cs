using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CoreLibrary.AI
{
    /// <summary>
    /// Базовая реализация нода, из нее в дальнейшем планируется наследовать все ноды которые содержат в себе логику выполнения.
    /// </summary>
    public abstract class Node : INode, IEnumerable
    {
        public string Name { get; set; }

        protected IEnumerable<INode> Children = new List<INode>();

        public Node(string name)
        {
            Name = name;
        }

        public Node()
        {
            Name = "no name node";
        }

        public abstract Status Process();

        public void Add(INode node)
        {
            Children = Children.Append(node);
        }

        public IEnumerator GetEnumerator()
        {
            return Children.GetEnumerator();
        }
    }
}

