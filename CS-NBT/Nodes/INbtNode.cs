namespace nbtlib.Nodes
{
    public interface INbtNode
    {
        string Name { get; set; }
        NbtType Type { get; }
        INbtContainerNode Parent { get; set; }

        void Load(NbtReader reader, INbtContainerNode parent);
        void Save(NbtWriter writer);
        void SetParent(INbtContainerNode node);

        T Get<T>();
    }
}