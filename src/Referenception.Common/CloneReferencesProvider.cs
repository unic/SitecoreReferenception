namespace Referenception.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Referenception.Core;
    using Referenception.Core.Data;
    using Referenception.Core.Nodes;
    using Referenception.Core.Providers;
    using Referenception.Core.Utilities;

    using Sitecore.Data.Items;

    public class CloneReferencesProvider : ReferenceProviderBase
    {
        public override IEnumerable<DataTable> GetData(Item item)
        {
            return Enumerable.Empty<DataTable>();
        }
    }
}
