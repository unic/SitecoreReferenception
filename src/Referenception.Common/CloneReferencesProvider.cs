namespace Referenception.Common
{
    using System.Data;
    using System.Linq;
    using Referenception.Core.Extensions;
    using Referenception.Core.Providers;
    using Referenception.Core.Utilities;

    using Sitecore.Data;
    using Sitecore.Data.Items;
    using Sitecore.Globalization;

    public class CloneReferencesProvider : ReferenceProviderBase
    {
        public override DataTable GetData(Item sourceItem)
        {
            var table = new DataTable();

            table.Columns.Add(Translate.Text("Id"), typeof(ID));
            table.Columns.Add(Translate.Text("Display name"), typeof(string));
            table.Columns.Add(Translate.Text("Item path"), typeof(string));

            foreach (var item in ItemReferrer.GetClonedItems(sourceItem))
            {
                table.Rows.Add(item.ID, item.DisplayName, item.Paths.FullPath);
            }

            return table;
        }

        public override ID GetLinkItemId(DataRow row)
        {
            return (ID)row[Translate.Text("Id")];
        }
    }
}
