namespace Referenception.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Referenception.Core.Data;
    using Referenception.Core.Extensions;
    using Referenception.Core.Providers;

    using Sitecore.Data.Items;

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

        public override IEnumerable<DataTable> GetData(Item sourceItem)
        {
            var fields = sourceItem.Fields
                .Where(field => this.FieldTypes.Any(type => type == field.Type))
                .Where(field => !field.IsStandardTemplateField());

            foreach (var field in fields)
            {
                var dataTable = new DataTable();
                dataTable.Title = field.DisplayName;

                foreach (var id in field.Value.Split('|'))
                {
                    var item = sourceItem.Database.GetItem(id);
                    if (item == null) continue;

                    dataTable.Rows.Add(item.ToDataRow());
                }

                yield return dataTable;
            }
        }
    }
}
