using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nbtlib.Nodes
{
    public class NbtFloat : NbtNode
    {
        public override NbtType Type => NbtType.Float;

        public float Value { get; set; }

        public override void Load(NbtReader reader, INbtContainerNode parent)
        {
            base.Load(reader, parent);
            Value = reader.ReadSingle();
        }

        public override void Save(NbtWriter writer)
        {
            base.Save(writer);
            writer.Write(Value);
        }

        public static implicit operator float(NbtFloat nbt)
        {
            return nbt.Value;
        }
    }
}
