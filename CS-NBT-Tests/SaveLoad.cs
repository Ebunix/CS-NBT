using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using nbtlib;
using nbtlib.Nodes;

namespace CS_NBT_Tests
{
    [TestClass]
    public class SaveLoad
    {
        [TestMethod]
        public void TestSaveEmpty()
        {
            if (File.Exists("test.nbt"))
                File.Delete("test.nbt");

            NbtCompound expected = new NbtCompound();
            
            using (NbtWriter w = new NbtWriter(File.Open("test.nbt", FileMode.Create)))
                w.SaveTree(expected);

            NbtCompound loaded;
            using (NbtReader r = new NbtReader(File.Open("test.nbt", FileMode.Open)))
                loaded = r.GetTree();

            Assert.AreEqual(expected, loaded);
        }
    }
}
