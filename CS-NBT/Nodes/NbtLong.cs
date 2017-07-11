using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nbtlib.Nodes
{
    public class NbtLong : NbtNode
    {
        public override NbtType Type => NbtType.Long;
        public long Value { get; set; }

        public override void Load(NbtReader reader, INbtContainerNode parent)
        {
            base.Load(reader, parent);
            Value = reader.ReadInt64();
        }

        public override void Save(NbtWriter writer)
        {
            base.Save(writer);
            writer.Write(Value);
        }

        public static implicit operator long(NbtLong nbt)
        {
            return nbt.Value;
        }
    }
}
