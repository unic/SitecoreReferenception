namespace Referenception.Core.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Extensions;
    using Referenception.Core.Providers;
    using Sitecore.Data.Items;
    using Sitecore.Diagnostics;

    /// <summary>
    /// The configuration factory.
    /// </summary>
    public static class ConfigurationFactory
    {
        /// <summary>
        /// The lock object
        /// </summary>
        private static readonly object LockObject = new object();

        /// <summary>
        /// The internal cache
        /// </summary>
        private static readonly IDictionary<string, IEnumerable<ReferenceProviderBase>> Cache;

        /// <summary>
        /// The configuration
        /// </summary>
        private static readonly ReferenceptionConfig Config;

        /// <summary>
        /// Initializes static members of the <see cref="ConfigurationFactory"/> class.
        /// </summary>
        static ConfigurationFactory()
        {
            Cache = new Dictionary<string, IEnumerable<ReferenceProviderBase>>();

            var configNode = Sitecore.Configuration.Factory.GetConfigNode("referenception");
            Config = Sitecore.Configuration.Factory.CreateObject<ReferenceptionConfig>(configNode);
        }

        /// <summary>
        /// Gets the configured providers.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>The configured providers</returns>
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
