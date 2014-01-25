namespace Referenception.Common
{
    using System;
    using System.Collections.Generic;
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
