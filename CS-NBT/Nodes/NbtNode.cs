using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nbtlib.Nodes
{
    public class NbtNode : INbtNode
    {
        public string Name { get; set; }
        public INbtContainerNode Parent { get; set; }
        public virtual NbtType Type => NbtType.End;

        public virtual void Load(NbtReader reader, INbtContainerNode parent)
        {
            Parent = parent;
            if (parent == null || parent.Type != NbtType.List)
            {
                reader.ReadType(); // Skip type byte
                Name = reader.ReadString();
            }
        }

        public virtual void Save(NbtWriter writer)
        {
            if (Parent == null || Parent.Type != NbtType.List)
            {
                writer.Write(Type);
                writer.Write(Name);
            }
        }

        public void SetParent(INbtContainerNode node)
        {
            Parent.Detach(this);
            node.Attach(this);
        }

        public T Get<T>()
        {
            object o = null;
            var type = typeof(T);

            try
            {
                if (type == typeof(byte))
                    o = ((NbtString)this).Value;
                if (type == typeof(short))
                    o = ((NbtShort)this).Value;
                if (type == typeof(int))
                    o = ((NbtInt)this).Value;
                if (type == typeof(long))
                    o = ((NbtLong)this).Value;
                if (type == typeof(float))
                    o = ((NbtFloat)this).Value;
                if (type == typeof(double))
                    o = ((NbtDouble)this).Value;
                if (type == typeof(string))
                    o = ((NbtString)this).Value;
                if (type == typeof(byte[]))
                    o = ((NbtByteArray)this).Value;
                if (type == typeof(int[]))
                    o = ((NbtIntArray)this).Value;
            }
            catch (InvalidCastException) { }

            if (o == null)
                return default(T);
            return (T)o;
        }
    }
}
