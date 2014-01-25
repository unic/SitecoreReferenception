namespace Referenception.Core.Extensions
{
    using Sitecore.Configuration;
    using Sitecore.Data.Fields;
    using Sitecore.Data.Managers;

    /// <summary>
    /// The field extension methods.
    /// </summary>
    public static class FieldExtension
    {
        /// <summary>
        /// Determines whether the field is a standard template field.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <returns>Whether the field is a standard template field.</returns>
        public static bool IsStandardTemplateField(this Field field)
        {
            if (field == null) return false;

            var template = TemplateManager.GetTemplate(Settings.DefaultBaseTemplate, field.Database);
            if (template == null) return false;

            return template.ContainsField(field.ID);
        }
    }
}
