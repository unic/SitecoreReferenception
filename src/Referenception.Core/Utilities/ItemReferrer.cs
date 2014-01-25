namespace Referenception.Core.Utilities
{
    using System.Collections.Generic;
    using System.Linq;

    using Sitecore;
    using Sitecore.Data.Items;
    using Sitecore.Diagnostics;
    using Sitecore.Links;

    public static class ItemReferrer
    {
        public static IEnumerable<Item> GetLinkedItems(Item sourceItem)
        {
            return GetReferrers(sourceItem)
                    .Where(link => !IsClonedItem(link))
                    .Where(link => link.GetSourceItem() != null)
                    .Select(link => link.GetSourceItem())
                    .Where(item => item.Database == sourceItem.Database)
                    .Where(item => item.Language == sourceItem.Language)
                    .ToList();
        }
        
        public static IEnumerable<Item> GetClonedItems(Item sourceItem)
        {
            return GetReferrers(sourceItem)
                    .Where(IsClonedItem)
                    .Where(link => link.GetSourceItem() != null)
                    .Select(link => link.GetSourceItem())
                    .Where(item => item.Database == sourceItem.Database)
                    .Where(item => item.Language == sourceItem.Language)
                    .ToList();
        }
        
        private static IEnumerable<ItemLink> GetReferrers(Item source)
        {
            return Globals.LinkDatabase.GetReferrers(source);
        }

        private static bool IsClonedItem(ItemLink link)
        {
            return link.SourceFieldID == FieldIDs.Source;
        }
    }
}
