namespace Referenception.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Referenception.Core;
    using Referenception.Core.Data;
    using Referenception.Core.Extensions;
    using Referenception.Core.Providers;
    using Referenception.Core.Utilities;

    using Sitecore.Data.Items;

    public class CloneReferencesProvider : ReferenceProviderBase
    {
        public override IEnumerable<DataTable> GetData(Item sourceItem)
        {
            var table = new DataTable();
            table.Rows.AddRange(ItemReferrer.GetClonedItems(sourceItem).Select(item => item.ToDataRow()));
            yield return table;
        }
    }
}
