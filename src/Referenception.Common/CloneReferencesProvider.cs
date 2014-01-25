using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Referenception.Common
{
    using Referenception.Core;

    public class CloneReferencesProvider : ReferenceProviderBase
    {
        public CloneReferencesProvider(ReferenceContext context) : base(context)
        {
        }

        public override IEnumerable<INode> GetChildren()
        {
            throw new NotImplementedException();
        }
    }
}
