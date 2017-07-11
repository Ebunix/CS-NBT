using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nbtlib.Nodes
{
    public class NbtByteArray : NbtNode
    {
        public override NbtType Type => NbtType.ByteArray;
        public byte[] Value
        {
            get
            {
                if (data == null)
                { 
                    reader.BaseStream.Seek(dataLocation, System.IO.SeekOrigin.Begin);
                    data = reader.ReadBytes(dataLength);
                }
                return data;
            }
            set { data = value; }
        }

        private long dataLocation;
        private int dataLength;
        private NbtReader reader;
        private byte[] data;

        public override void Load(NbtReader reader, INbtContainerNode parent)
        {
            base.Load(reader, parent);
            dataLength = reader.ReadInt32();
            dataLocation = reader.BaseStream.Position;
            this.reader = reader;
        }

        public override void Save(NbtWriter writer)
        {
            base.Save(writer);
            writer.Write(Value);
        }

        public static implicit operator byte[] (NbtByteArray nbt)
        {
            return nbt.Value;
        }
    }
}
