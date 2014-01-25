namespace Referenception.Core
{
    using System.Collections.Generic;

    public abstract class NodeBase : INode
    {
        public virtual string DisplayName { get; set; }

        public virtual string Icon { get; set; }

        public ReferenceContext Context { get; private set; }

        public abstract IEnumerable<INode> GetChildren();

        protected NodeBase(ReferenceContext context)
        {
            this.Context = context;
        }
    }
}
