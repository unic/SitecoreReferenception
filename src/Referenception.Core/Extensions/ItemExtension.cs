using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Referenception.Core.Extensions
{
    using System.Collections;

    using Referenception.Core.Nodes;

    using Sitecore;
    using Sitecore.Data;
    using Sitecore.Data.Items;
    using Sitecore.Data.Managers;
    using Sitecore.Data.Templates;
    using Sitecore.Links;

    public static class ItemExtension
    {
        public static bool HasBaseTemplate(this Item item, string baseTemplate)
        {
            if (item == null || string.IsNullOrWhiteSpace(baseTemplate)) return false;

            Template template = TemplateManager.GetTemplate(item);
            if (template == null) return false;

            if (ID.IsID(baseTemplate) || ShortID.IsShortID(baseTemplate))
            {
                return template.InheritsFrom(new ID(baseTemplate));
            }

            return template.InheritsFrom(baseTemplate);
        }
        
        public static IEnumerable<Item> GetLinkedItems(this Item item)
        {
            if (item == null) return Enumerable.Empty<Item>();
            
            var links = Globals.LinkDatabase.GetReferrers(item);
            if (links == null)
            {
                return Enumerable.Empty<Item>();
            }

            var database = item.Database;
            var language = item.Language;
            var items = new List<Item>();
            foreach (var link in links.Where(link => link.SourceDatabaseName == database.Name))
            {
                var referenceItem = database.Items[link.SourceItemID, language];
                if (referenceItem != null)
                {
                    items.Add(referenceItem);
                }
            }

            return items;
        }
    }
}
