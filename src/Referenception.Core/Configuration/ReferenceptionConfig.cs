namespace Referenception.Core.Configuration
{
    using System.Collections.Generic;
    using Referenception.Core.Providers;

    public class ReferenceptionConfig
    {
        private readonly List<ReferenceProviderBase> providers = new List<ReferenceProviderBase>();

        public List<ReferenceProviderBase> Providers
        {
            get
            {
                return this.providers;
            }
        }
    }
}
