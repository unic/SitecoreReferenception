namespace Referenception.Providers
{
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using Referenception.Core.Extensions;
    using Referenception.Core.Providers;
    using Referenception.Core.Utilities;
    using Sitecore.Data;
    using Sitecore.Data.Items;
    using Sitecore.Globalization;

    /// <summary>
    /// The field reference provider.
    /// </summary>
    public class FieldReferencesProvider : ReferenceProviderBase
    {
        /// <summary>
        /// The field types
        /// </summary>
        private readonly List<string> fieldTypes = new List<string>();

        /// <summary>
        /// Gets the field types.
        /// </summary>
        /// <value>
        /// The field types.
        /// </value>
        public List<string> FieldTypes
        {
            get
            {
                return this.fieldTypes;
            }
        }

        /// <summary>
        /// Gets the data table.
        /// </summary>
        /// <param name="sourceItem">The source item.</param>
        /// <returns>The data table</returns>
        public override DataTable GetData(Item sourceItem)
        {
            var table = new DataTable();

            table.Columns.Add(Translate.Text("Field name"), typeof(string));
            table.Columns.Add(Translate.Text("Id"), typeof(ID));
            table.Columns.Add(Translate.Text("Display name"), typeof(string));
            table.Columns.Add(Translate.Text("Item path"), typeof(string));
            table.Columns.Add(ReferenceProviderBase.ToolTipColumnName, typeof(IDictionary<string, string>));

            var fields = sourceItem.Fields
                .Where(field => this.FieldTypes.Any(type => type == field.Type))
                .Where(field => !field.IsStandardTemplateField());

            foreach (var field in fields)
            {
                var fieldNameAdded = false;
                foreach (var id in field.Value.Split('|'))
                {
                    var item = sourceItem.Database.GetItem(id);
                    if (item == null) continue;

                    var fieldName = !fieldNameAdded ? field.DisplayName : string.Empty;
                    fieldNameAdded = true;

                    table.Rows.Add(fieldName, item.ID, item.DisplayName, item.Paths.FullPath, TooltipUtil.GetItemTooltip(item));
                }
            }

            return table;
        }

        /// <summary>
        /// Gets the link item identifier.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <returns>
        /// The link item ID
        /// </returns>
        public override ID GetLinkItemId(DataRow row)
        {
            return (ID)row[Translate.Text("Id")];
        }

        /// <summary>
        /// Gets the tooltip.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <returns>
        /// The tooltip key-value collection
        /// </returns>
        public override IDictionary<string, string> GetTooltip(DataRow row)
        {
            return (IDictionary<string, string>)row[ToolTipColumnName];
        }
    }
}
