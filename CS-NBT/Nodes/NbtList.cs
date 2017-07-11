using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nbtlib.Nodes
{
    public class NbtList : NbtContainerNode
    {
        public override NbtType Type => NbtType.List;
        public NbtType ListType
        {
            get
            {
                if (Children == null || Count == 0)
                    return NbtType.End;
                return Children.First().Type;
            }
        }

        public override void Load(NbtReader reader, INbtContainerNode parent)
        {
            base.Load(reader, parent);
            var listType = reader.ReadType();
            int length = reader.ReadInt32();
            for (int i = 0; i < length; i++)
            {
                INbtNode node = NodeFactory.CreateNode(listType);
                node.Load(reader, this);
                Children.Add(node);
            }
        }

        public override void Save(NbtWriter writer)
        {
            base.Save(writer);
            writer.Write(ListType);
            writer.Write(Count);

            foreach (var node in Children)
                node.Save(writer);
        }
    }
}
