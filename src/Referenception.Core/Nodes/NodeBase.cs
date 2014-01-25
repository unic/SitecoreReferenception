namespace Referenception.Core.Nodes
{
    using System.Collections.Generic;

    public abstract class NodeBase : INode
    {
        public virtual string DisplayName { get; set; }

        public virtual string Icon { get; set; }

        public ReferenceContext Context { get; set; }

        public abstract IEnumerable<INode> GetChildren();
    }
}
