using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Referenception.Common
{
    using Referenception.Core;

    public class FieldReferencesProvider : ReferenceProviderBase
    {
        public FieldReferencesProvider(ReferenceContext context)
            : base(context)
        {
        }

        public override IEnumerable<INode> GetChildren()
        {
            throw new NotImplementedException();
        }
    }
}
