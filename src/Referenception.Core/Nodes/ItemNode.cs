namespace Referenception.Core.Nodes
{
    using System.Collections.Generic;

    using Referenception.Core.Configuration;

    public class ItemNode : NodeBase
    {
        public override IEnumerable<INode> GetChildren()
        {
            var providers = ConfigurationFactory.GetProviders(this.Context.Item);
            foreach (var provider in providers)
            {
                provider.DisplayName = provider.ToString();
                provider.Context = this.Context;
                yield return provider;
            }
        }
    }
}
