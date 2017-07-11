using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nbtlib.Nodes
{
    public class NbtCompound : NbtContainerNode
    {
        public override NbtType Type => NbtType.Compound;

        public override void Load(NbtReader reader, INbtContainerNode parent)
        {
            base.Load(reader, parent);
            while (true)
            {
                var listType = reader.PeekType();
                if (listType == NbtType.End)
                    break;
                INbtNode node = NodeFactory.CreateNode(listType);
                node.Load(reader, this);
                Children.Add(node);
            }
        }

        public override void Save(NbtWriter writer)
        {
            base.Save(writer);
            foreach (var node in Children)
                node.Save(writer);
            writer.Write(NbtType.End);
        }
    }
}
