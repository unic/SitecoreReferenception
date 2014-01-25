namespace Referenception.Core.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Configuration.Provider;
    using System.Xml;
    using System.Linq;

    using Referenception.Core.Providers;

    using Sitecore.Data;
    using Sitecore.Data.Items;
    using Sitecore.Data.Managers;
    using Sitecore.Data.Templates;
    using Sitecore.Diagnostics;
    using Extensions;

    public static class ConfigurationFactory
    {
        private static readonly object LockObject = new object();

        private static readonly IDictionary<string, IEnumerable<ReferenceProviderBase>> Cache;

        private static readonly ReferenceptionConfig Config;

        static ConfigurationFactory()
        {
            Cache = new Dictionary<string, IEnumerable<ReferenceProviderBase>>();

            var configNode = Sitecore.Configuration.Factory.GetConfigNode("referenception");
            Config = Sitecore.Configuration.Factory.CreateObject<ReferenceptionConfig>(configNode);
        }

        public static IEnumerable<ReferenceProviderBase> GetProviders(Item item)
        {
            Assert.ArgumentNotNull(item, "item");

            var templateName = item.TemplateName;
            lock (LockObject)
            {
                if (Cache.ContainsKey(templateName))
                {
                    return Cache[templateName];
                }

                var validProviders = new List<ReferenceProviderBase>();
                validProviders.AddRange(Config.Providers.Where(
                        provider =>
                            provider.Templates.Contains(item.TemplateName, StringComparer.OrdinalIgnoreCase)
                            || provider.Templates.Any(item.HasBaseTemplate)));

                Cache.Add(templateName, validProviders);
                return validProviders;
            }
        }
    }
}
