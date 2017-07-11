using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nbtlib.Nodes
{
    public interface INbtContainerNode : INbtNode
    {
        int Count { get;}

        INbtNode Get(string name);
        INbtNode Get(int index);
        INbtContainerNode Container(string name);
        INbtContainerNode Container(int index);

        void Attach(INbtNode node);
        void Detach(INbtNode node);
    }
}
