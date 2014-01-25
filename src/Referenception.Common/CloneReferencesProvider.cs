namespace Referenception.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Referenception.Core;
    using Referenception.Core.Nodes;

    public class CloneReferencesProvider : ReferenceProviderBase
    {
        public override IEnumerable<INode> GetChildren()
        {
            return Enumerable.Empty<INode>();
        }
    }
}
