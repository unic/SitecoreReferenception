using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Referenception.Common
{
    using Referenception.Core;
    using Referenception.Core.Extensions;
    using Referenception.Core.Nodes;
    using Referenception.Core.Providers;
    using Referenception.Core.Utilities;

    using Sitecore.Data.Items;

    public class UsageReferencesProvider : ReferenceProviderBase
    {
        public override IEnumerable<DataTable> GetData(Item sourceItem)
        {
            var table = new DataTable();
            table.Rows.AddRange(ItemReferrer.GetLinkedItems(sourceItem).Select(item => item.ToDataRow()));
            yield return table;
        }
    }
}
