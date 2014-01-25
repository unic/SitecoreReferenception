namespace Referenception.Common
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

    public class FieldReferencesProvider : ReferenceProviderBase
    {
        private readonly List<string> fieldTypes = new List<string>();

        public List<string> FieldTypes
        {
            get
            {
                return this.fieldTypes;
            }
        }

        public override DataTable GetData(Item sourceItem)
        {
            var table = new DataTable();

            table.Columns.Add(Translate.Text("Field name"), typeof(string));
            table.Columns.Add(Translate.Text("Id"), typeof(ID));
            table.Columns.Add(Translate.Text("Display name"), typeof(string));
            table.Columns.Add(Translate.Text("Item path"), typeof(string));

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

                    table.Rows.Add(fieldName, item.ID, item.DisplayName, item.Paths.FullPath);
                }
            }

            return table;
        }

        public override ID GetLinkItemId(DataRow row)
        {
            return (ID)row[Translate.Text("Id")];
        }
    }
}
