using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nbtlib.Nodes
{
    public class NbtIntArray : NbtNode
    {
        public override NbtType Type => NbtType.IntArray;
        public int[] Value { get; set; }

        public override void Load(NbtReader reader, INbtContainerNode parent)
        {
            base.Load(reader, parent);
            int len = reader.ReadInt32();
            Value = new int[len];
            for (int i = 0; i < len; i++)
                Value[i] = reader.ReadInt32();
        }

        public override void Save(NbtWriter writer)
        {
            base.Save(writer);
            writer.Write(Value.Length);
            foreach (var val in Value)
                writer.Write(val);
        }

        public static implicit operator int[] (NbtIntArray nbt)
        {
            return nbt.Value;
        }
    }
}
