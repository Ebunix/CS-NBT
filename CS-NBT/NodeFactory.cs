using nbtlib.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nbtlib
{
    internal class NodeFactory
    {
        public static INbtNode CreateNode(NbtType type)
        {
            switch (type)
            {
                case NbtType.Byte:
                    return new NbtByte();
                case NbtType.Short:
                    return new NbtShort();
                case NbtType.Int:
                    return new NbtInt();
                case NbtType.Long:
                    return new NbtLong();
                case NbtType.Float:
                    return new NbtFloat();
                case NbtType.Double:
                    return new NbtDouble();
                case NbtType.String:
                    return new NbtString();
                case NbtType.Compound:
                    return new NbtCompound();
                case NbtType.List:
                    return new NbtList();
                case NbtType.ByteArray:
                    return new NbtByteArray();
                case NbtType.IntArray:
                    return new NbtIntArray();
            }
            return null;
        }
    }
}
