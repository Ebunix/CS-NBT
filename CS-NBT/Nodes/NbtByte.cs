using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nbtlib.Nodes
{
    public class NbtByte : NbtNode
    {
        public override NbtType Type => NbtType.Byte;
        public byte Value { get; set; }

        public override void Load(NbtReader reader, INbtContainerNode parent)
        {
            base.Load(reader, parent);
            Value = reader.ReadByte();
        }

        public override void Save(NbtWriter writer)
        {
            base.Save(writer);
            writer.BaseStream.WriteByte(Value);
        }

        public static implicit operator byte(NbtByte nbt)
        {
            return nbt.Value;
        }
    }
}
