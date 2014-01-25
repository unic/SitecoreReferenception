namespace Referenception.Core.Utilities
{
    using System.Collections.Generic;
    using System.Linq;
    using Sitecore;
    using Sitecore.Data.Items;
    using Sitecore.Links;

    /// <summary>
    /// The item referrer.
    /// </summary>
    public static class ItemReferrer
    {
        /// <summary>
        /// Gets the linked items.
        /// </summary>
        /// <param name="sourceItem">The source item.</param>
        /// <returns>The linked items.</returns>
        public static IEnumerable<Item> GetLinkedItems(Item sourceItem)
        {
            return GetReferrers(sourceItem)
                    .Where(link => !IsClonedItem(link))
                    .Where(link => link.GetSourceItem() != null)
                    .Select(link => link.GetSourceItem())
                    .Where(item => item.Database == sourceItem.Database)
                    .Where(item => item.Language == sourceItem.Language)
                    .Distinct(new ItemEqualityComparer())
                    .ToList();
        }

        /// <summary>
        /// Gets the cloned items.
        /// </summary>
        /// <param name="sourceItem">The source item.</param>
        /// <returns>The cloned items.</returns>
        public static IEnumerable<Item> GetClonedItems(Item sourceItem)
        {
            return GetReferrers(sourceItem)
                    .Where(IsClonedItem)
                    .Where(link => link.GetSourceItem() != null)
                    .Select(link => link.GetSourceItem())
                    .Where(item => item.Database == sourceItem.Database)
                    .Where(item => item.Language == sourceItem.Language)
                    .Distinct(new ItemEqualityComparer())
                    .ToList();
        }

        /// <summary>
        /// Gets the referrers.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>The referrers.</returns>
        private static IEnumerable<ItemLink> GetReferrers(Item source)
        {
            return Globals.LinkDatabase.GetReferrers(source);
        }

        /// <summary>
        /// Determines whether is a cloned item.
        /// </summary>
        /// <param name="link">The link.</param>
        /// <returns>Whether it is a cloned item.</returns>
        private static bool IsClonedItem(ItemLink link)
        {
            return link.SourceFieldID == FieldIDs.Source;
        }

        /// <summary>
        /// Compares two items for equality
        /// </summary>
        private class ItemEqualityComparer : IEqualityComparer<Item>
        {
            /// <summary>
            /// Determines whether the specified objects are equal.
            /// </summary>
            /// <param name="firstItem">The first object of type <paramref name="Item" /> to compare.</param>
            /// <param name="secondItem">The second object of type <paramref name="Item" /> to compare.</param>
            /// <returns>
            /// true if the specified objects are equal; otherwise, false.
            /// </returns>
            public bool Equals(Item firstItem, Item secondItem)
            {
                return firstItem.ID.Equals(secondItem.ID);
            }

            /// <summary>
            /// Returns a hash code for this instance.
            /// </summary>
            /// <param name="item">The object.</param>
            /// <returns>
            /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
            /// </returns>
            public int GetHashCode(Item item)
            {
                return item.ID.GetHashCode();
            }
        }
    }
}
