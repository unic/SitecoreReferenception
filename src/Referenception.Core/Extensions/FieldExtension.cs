namespace Referenception.Core.Extensions
{
    using Sitecore.Configuration;
    using Sitecore.Data.Fields;
    using Sitecore.Data.Managers;

    public static class FieldExtension
    {
        public static bool IsStandardTemplateField(this Field field)
        {
            if (field == null) return false;

            var template = TemplateManager.GetTemplate(Settings.DefaultBaseTemplate, field.Database);
            if (template == null) return false;

            return template.ContainsField(field.ID);
        }
    }
}
