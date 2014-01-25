namespace Referenception.Core.Nodes
{
    using System.Collections.Generic;

    using Referenception.Core.Configuration;

    public class ItemNode : NodeBase
    {
        public override IEnumerable<INode> GetChildren()
        {
            return ConfigurationFactory.GetProviders(this.Context);
        }
    }
}
