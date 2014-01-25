namespace Referenception.Core.Nodes
{
    using System.Collections.Generic;

    using Referenception.Core.Configuration;

    using Sitecore.Data.Managers;
    using Sitecore.Resources;

    public class ItemNode : NodeBase
    {
        public override IEnumerable<INode> GetChildren()
        {
            var providers = ConfigurationFactory.GetProviders(this.Context.Item);
            foreach (var provider in providers)
            {
                provider.DisplayName = provider.ToString();
                provider.Context = this.Context;
                provider.Icon = ThemeManager.GetImage("Applications/16x16/folder_add.png", IconWidth, IconHeight);
                yield return provider;
            }
        }
    }
}
