namespace Referenception.Core.Nodes
{
    using System.Collections.Generic;

    public abstract class ReferenceProviderBase : NodeBase
    {
        private readonly List<string> templates = new List<string>();

        public List<string> Templates
        {
            get
            {
                return this.templates;
            }
        }
    }
}
