namespace Referenception.Core.Extensions
{
    using Sitecore.Data;
    using Sitecore.Data.Items;
    using Sitecore.Data.Managers;
    using Sitecore.Data.Templates;

    /// <summary>
    /// The item extension methods.
    /// </summary>
    public static class ItemExtensions
    {
        /// <summary>
        /// Determines whether the item has a base template.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="baseTemplate">The base template.</param>
        /// <returns>Whether the item has a base template</returns>
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
    }
}
