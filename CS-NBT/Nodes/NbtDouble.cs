using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nbtlib.Nodes
{
    public class NbtDouble : NbtNode
    {
        public override NbtType Type => NbtType.Double;
        public double Value { get; set; }

        public override void Load(NbtReader reader, INbtContainerNode parent)
        {
            base.Load(reader, parent);
            Value = reader.ReadDouble();
        }

        public override void Save(NbtWriter writer)
        {
            base.Save(writer);
            writer.Write(Value);
        }

        public static implicit operator double(NbtDouble nbt)
        {
            return nbt.Value;
        }
    }
}
