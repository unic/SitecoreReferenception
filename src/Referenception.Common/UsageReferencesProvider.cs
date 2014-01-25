using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Referenception.Common
{
    using Referenception.Core;

    public class UsageReferencesProvider : ReferenceProviderBase
    {
        public UsageReferencesProvider(ReferenceContext context)
            : base(context)
        {
        }

        public override IEnumerable<INode> GetChildren()
        {
            throw new NotImplementedException();
        }
    }
}
