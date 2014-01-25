namespace Referenception.Core.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Xml;
    using System.Linq;

    using Referenception.Core.Extensions;
    using Referenception.Core.Nodes;

    using Sitecore.Data;
    using Sitecore.Data.Items;
    using Sitecore.Data.Managers;
    using Sitecore.Data.Templates;
    using Sitecore.Diagnostics;

    public static class ConfigurationFactory
    {
        public static IEnumerable<ReferenceProviderBase> GetProviders(ReferenceContext context)
        {
            Assert.ArgumentNotNull(context, "context");
            Assert.IsNotNull(context.Item, "Item of context must not be null");

            var configNode = Sitecore.Configuration.Factory.GetConfigNode("referenception");
            var config = Sitecore.Configuration.Factory.CreateObject<ReferenceptionConfig>(configNode);
            foreach (var provider in config.Providers)
            {
                if (provider.Templates.Contains(context.Item.TemplateName, StringComparer.OrdinalIgnoreCase)
                    || provider.Templates.Any(template => context.Item.HasBaseTemplate(template)))
                {
                    yield return provider;
                }
            }
        }
    }
}
