using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Referenception.Core
{
    public abstract class ReferenceProviderBase : NodeBase
    {
        protected ReferenceProviderBase(ReferenceContext context) : base(context)
        {
        }
    }
}
