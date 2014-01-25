using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Referenception.Common
{
    using Referenception.Core;
    using Referenception.Core.Data;
    using Referenception.Core.Nodes;
    using Referenception.Core.Providers;
    using Referenception.Core.Utilities;

    public class UsageReferencesProvider : ReferenceProviderBase
    {
        public override IEnumerable<DataTable> GetData()
        {
            return Enumerable.Empty<DataTable>();
        }
    }
}
