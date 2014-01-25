namespace Referenception.Core.Nodes
{
    using System.Collections.Generic;

    using Sitecore.Data.Managers;
    using Sitecore.Resources;

    public abstract class NodeBase : INode
    {
        protected const int IconWidth = 16;

        protected const int IconHeight = 16;
        
        private string icon;

        private string displayName;

        public virtual string DisplayName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.displayName)
                    && this.Context != null
                    && this.Context.Item != null)
                {
                    this.displayName = this.Context.Item.DisplayName;
                }

                return this.displayName;
            }

            set
            {
                this.displayName = value;
            }
        }

        public virtual string Icon
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.displayName)
                    && this.Context != null
                    && this.Context.Item != null)
                {
                    this.icon = ThemeManager.GetIconImage(this.Context.Item, IconWidth, IconHeight, "", "");
                }

                return this.icon;
            }

            set
            {
                this.icon = value;
            }
        }

        public ReferenceContext Context { get; set; }

        public abstract IEnumerable<INode> GetChildren();
    }
}
