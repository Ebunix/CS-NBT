using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nbtlib.Nodes
{
    public class NbtShort : NbtNode
    {
        public override NbtType Type => NbtType.Short;

        public short Value { get; set; }

        public override void Load(NbtReader reader, INbtContainerNode parent)
        {
            base.Load(reader, parent);
            Value = reader.ReadInt16();
        }

        public override void Save(NbtWriter writer)
        {
            base.Save(writer);
            writer.Write(Value);
        }

        public static implicit operator short(NbtShort nbt)
        {
            return nbt.Value;
        }
    }
}
