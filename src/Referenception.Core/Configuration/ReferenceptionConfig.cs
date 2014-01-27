namespace Referenception.Core.Configuration
{
    using System.Collections.Generic;
    using Referenception.Core.Providers;

    /// <summary>
    /// The referenception configuration.
    /// </summary>
    public class ReferenceptionConfig
    {
        /// <summary>
        /// The providers
        /// </summary>
        private readonly List<ReferenceProviderBase> providers = new List<ReferenceProviderBase>();

        /// <summary>
        /// Gets the providers.
        /// </summary>
        /// <value>
        /// The providers.
        /// </value>
        public List<ReferenceProviderBase> Providers
        {
            get
            {
                return this.providers;
            }
        }
    }
}
