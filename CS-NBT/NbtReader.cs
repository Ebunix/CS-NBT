using nbtlib.Nodes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace nbtlib
{
    public class NbtReader : BinaryReader
    {
        public NbtReader(Stream input) : base(input)
        {
        }

        public NbtCompound GetTree()
        {
            INbtNode node = NodeFactory.CreateNode(NbtType.Compound);
            node.Load(this, null);
            return (NbtCompound)node;
        }

        public NbtType ReadType()
        {
            return (NbtType)ReadByte();
        }

        public new short ReadInt16()
        {
            return BitConverter.ToInt16(Reverse(2), 0);
        }

        public new int ReadInt32()
        {
            return BitConverter.ToInt32(Reverse(4), 0);
        }

        public new long ReadInt64()
        {
            return BitConverter.ToInt64(Reverse(8), 0);
        }

        public new float ReadSingle()
        {
            return BitConverter.ToSingle(Reverse(4), 0);
        }

        public new double ReadDouble()
        {
            return BitConverter.ToDouble(Reverse(8), 0);
        }

        public NbtType PeekType()
        {
            try
            {
                var b = ReadByte();
                BaseStream.Seek(-1, SeekOrigin.Current);
                return (NbtType)b;
            }
            catch { return NbtType.End; }
        }

        public new string ReadString()
        {
            int len = ReadInt16();
            var dat = ReadBytes(len);
            return Encoding.UTF8.GetString(dat);
        }

        private byte[] Reverse(int v)
        {
            var dta = ReadBytes(v);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(dta);
            return dta;
        }
    }
}
