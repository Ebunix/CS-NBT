using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nbtlib.Nodes
{
    public class NbtContainerNode : NbtNode, INbtContainerNode
    {
        public int Count => Children.Count;
        protected List<INbtNode> Children { get; } = new List<INbtNode>();

        public INbtNode Get(string name)
        {
            foreach (var n in Children)
                if (n.Name == name)
                    return n;
            return null;
        }

        public INbtNode Get(int index)
        {
            if (index >= 0 && index < Count)
            {
                return Children[index];
            }
            return null;
        }

        public INbtContainerNode Container(string name)
        {
            foreach (var n in Children)
                if (n.Name == name)
                    return n as INbtContainerNode;
            return null;
        }

        public INbtContainerNode Container(int index)
        {
            if (index >= 0 && index < Count)
            {
                return Children[index] as INbtContainerNode;
            }
            return null;
        }

        public void Attach(INbtNode node)
        {
            if (!Children.Contains(node))
                Children.Add(node);
            node.Parent = this;
        }

        public void Detach(INbtNode node)
        {
            if (Children.Contains(node))
                Children.Remove(node);
            node.Parent = null;
        }
    }
}
