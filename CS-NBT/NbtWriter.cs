using System;
using System.IO;
using System.Text;

namespace nbtlib.Nodes
{
    public class NbtWriter : BinaryWriter
    {

        public NbtWriter(Stream output) : base(output)
        {
        }

        public new void Write(string text)
        {
            var utf8 = text == null ? new byte[0] : Encoding.UTF8.GetBytes(text);
            Write((short)utf8.Length);
            Write(utf8);
        }

        public new void Write(short n)
        {
            WriteRev(BitConverter.GetBytes(n));
        }

        public new void Write(int n)
        {
            WriteRev(BitConverter.GetBytes(n));
        }

        public new void Write(long n)
        {
            WriteRev(BitConverter.GetBytes(n));
        }

        public new void Write(float n)
        {
            WriteRev(BitConverter.GetBytes(n));
        }

        public new void Write(double n)
        {
            WriteRev(BitConverter.GetBytes(n));
        }

        public void Write(NbtType n)
        {
            BaseStream.WriteByte((byte)n);
        }

        public void SaveTree(NbtCompound compound)
        {
            compound.Save(this);
        }

        private void WriteRev(byte[] n)
        {
            if (BitConverter.IsLittleEndian)
                Array.Reverse(n);
            Write(n);
        }
    }
}