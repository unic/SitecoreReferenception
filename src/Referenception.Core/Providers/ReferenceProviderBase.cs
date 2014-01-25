namespace Referenception.Core.Providers
{
    using System.Collections.Generic;

    using Referenception.Core.Nodes;

    using Sitecore.Data.Items;

    public abstract class ReferenceProviderBase : IReferenceProvider
    {
        private readonly List<string> templates = new List<string>();

        public List<string> Templates
        {
            get
            {
                return this.templates;
            }
        }

        public virtual string Title { get; set; }

        public abstract IEnumerable<DataTable> GetData(Item item);
    }
}
