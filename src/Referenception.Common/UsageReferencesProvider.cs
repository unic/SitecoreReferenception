namespace Referenception.Common
{
    using System.Linq;
    using Referenception.Core.Extensions;
    using Referenception.Core.Nodes;
    using Referenception.Core.Providers;
    using Referenception.Core.Utilities;
    using Sitecore.Data.Items;

    public class UsageReferencesProvider : ReferenceProviderBase
    {
        public override DataTable GetData(Item sourceItem)
        {
            var table = new DataTable();
            table.Rows.AddRange(ItemReferrer.GetLinkedItems(sourceItem).Select(item => item.ToDataRow()));
            return table;
        }
    }
}
