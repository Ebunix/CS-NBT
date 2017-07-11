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
            RemoveTestFile();

            NbtCompound expected = new NbtCompound();
            using (NbtWriter w = OpenTestFile())
                w.SaveTree(expected);

            NbtCompound loaded;
            using (NbtReader r = ReadTestFile())
                loaded = r.GetTree();

            Assert.AreEqual(expected, loaded);
        }

        [TestMethod]
        public void TestSaveCompound()
        {
            NbtCompound expected = new NbtCompound();
            expected.Name = "RootCompound";
            expected.Attach(new NbtString { Name = "TestString", Value = "Test Value 123" });

            using (NbtWriter w = OpenTestFile())
                w.SaveTree(expected);

            NbtCompound loaded;
            using (NbtReader r = ReadTestFile())
                loaded = r.GetTree();

            Assert.AreEqual(expected, loaded);
        }

    //  Helpers
    // =========

    private static NbtReader ReadTestFile()
    {
        return new NbtReader(File.Open("test.nbt", FileMode.Open));
    }

    private static NbtWriter OpenTestFile()
    {
        return new NbtWriter(File.Open("test.nbt", FileMode.Create));
    }

    private static void RemoveTestFile()
    {
        if (File.Exists("test.nbt"))
            File.Delete("test.nbt");
    }
}
}
