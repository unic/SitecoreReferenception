namespace Referenception.Core.Providers
{
    using System.Collections.Generic;
    using Referenception.Core.Nodes;
    using Sitecore.Data.Items;

    public abstract class ReferenceProviderBase : IReferenceProvider
    {
        private readonly List<string> templates = new List<string>();

        protected ReferenceProviderBase()
        {
            this.HasFieldColumn = false;
        }

        public List<string> Templates
        {
            get
            {
                return this.templates;
            }
        }

        public virtual string Title { get; set; }

        public virtual bool HasFieldColumn { get; set; }

        public abstract DataTable GetData(Item item);
    }
}
