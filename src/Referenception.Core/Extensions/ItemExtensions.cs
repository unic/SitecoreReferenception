namespace Referenception.Core.Extensions
{
    using Referenception.Core.Nodes;
    using Sitecore.Data;
    using Sitecore.Data.Items;
    using Sitecore.Data.Managers;
    using Sitecore.Data.Templates;

    public static class ItemExtensions
    {
        public static DataRow ToDataRow(this Item item)
        {
            return new DataRow
                    {
                        Item = item,
                        Id = item.ID.ToString(),
                        DisplayName = item.DisplayName,
                        TemplateName = item.TemplateName,
                        ItemPath = item.Paths.FullPath
                    };
        }

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
