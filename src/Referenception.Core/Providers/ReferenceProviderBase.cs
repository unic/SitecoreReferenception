﻿namespace Referenception.Core.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    using Sitecore.Data;
    using Sitecore.Data.Items;

    public abstract class ReferenceProviderBase
    {
        private readonly List<string> templates = new List<string>();
        
        public List<string> Templates
        {
            get
            {
                return this.templates;
            }
        }

        public string Title { get; set; }

        public virtual ID GetLinkItemId(DataRow row)
        {
            return null;
        }

        public virtual IDictionary<string, string> GetTooltip(DataRow row)
        {
            return null;
        }

        public abstract DataTable GetData(Item item);
    }
}
