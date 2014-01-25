namespace Referenception.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Referenception.Core.Extensions;
    using Referenception.Core.Nodes;
    using Referenception.Core.Providers;

    using Sitecore.Data.Items;

    public class FieldReferencesProvider : ReferenceProviderBase
    {
        private readonly List<string> fieldTypes = new List<string>();

        public FieldReferencesProvider()
        {
            this.HasFieldColumn = true;
        }
        
        public List<string> FieldTypes
        {
            get
            {
                return this.fieldTypes;
            }
        }

        public override DataTable GetData(Item sourceItem)
        {
            var fields = sourceItem.Fields
                .Where(field => this.FieldTypes.Any(type => type == field.Type))
                .Where(field => !field.IsStandardTemplateField());

            var dataTable = new DataTable();
            foreach (var field in fields)
            {
                foreach (var id in field.Value.Split('|'))
                {
                    var item = sourceItem.Database.GetItem(id);
                    if (item == null) continue;

                    var dataRow = item.ToDataRow();
                    dataRow.FieldName = field.DisplayName;
                    dataTable.Rows.Add(dataRow);
                }
            }

            return dataTable;
        }
    }
}
