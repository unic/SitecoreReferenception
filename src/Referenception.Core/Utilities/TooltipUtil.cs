namespace Referenception.Core.Utilities
{
    using System.Collections.Generic;
    using Sitecore.Data.Items;
    using Sitecore.Globalization;

    /// <summary>
    /// The tooltip utility.
    /// </summary>
    public static class TooltipUtil
    {
        /// <summary>
        /// Gets the item tooltip.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>The item tooltip.</returns>
        public static IDictionary<string, string> GetItemTooltip(Item item)
        {
            var dictionary = new Dictionary<string, string>();
            dictionary.Add(Translate.Text("Template name"), item.TemplateName);
            dictionary.Add(Translate.Text("Template id"), item.TemplateID.ToString());
            dictionary.Add(Translate.Text("Created date"), item.Statistics.Created.ToString());
            dictionary.Add(Translate.Text("Updated date"), item.Statistics.Updated.ToString());
            dictionary.Add(Translate.Text("Revision"), item.Statistics.Revision);

            return dictionary;
        }
    }
}
