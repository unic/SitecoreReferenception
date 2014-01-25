namespace Referenception.Core.Nodes
{
    using System.Collections.Generic;

    public interface INode
    {
        string DisplayName { get; set; }

        string Icon { get; set; }

        ReferenceContext Context { get; }

        IEnumerable<INode> GetChildren();
    }
}
