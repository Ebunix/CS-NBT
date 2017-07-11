using nbtlib.Nodes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace nbtlib
{
    public class Program
    {
        public static void Main(string[] args)
        {
            NbtReader r = new NbtReader(File.Open("hello_world.nbt", FileMode.Open));
            NbtCompound compound = r.GetTree();
            r.Close();
            short lol = compound.Container("COMPOUND").Get("LOL").Get<short>();

            var save = new NbtCompound();
            save.Name = "Hallo";
            save.Attach(new NbtString() { Value = "ASDFGhjkl!" });
            save.Attach(new NbtList() { Name = "Listö" });
            save.Container("Listö").Attach(new NbtLong() { Value = long.MaxValue });
            save.Container("Listö").Attach(new NbtLong() { Value = long.MinValue });
            save.Container("Listö").Attach(new NbtInt() { Value = int.MinValue });
            save.Container("Listö").Get(2).SetParent(save);


            NbtWriter w = new NbtWriter(File.Open("out.nbt", FileMode.Create));
            w.SaveTree(save);
            w.Close();
        }
    }
}
