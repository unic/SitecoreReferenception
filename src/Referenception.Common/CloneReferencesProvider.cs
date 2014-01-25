namespace Referenception.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Referenception.Core;
    using Referenception.Core.Nodes;
    using Referenception.Core.Utilities;

    public class CloneReferencesProvider : ReferenceProviderBase
    {
        public override IEnumerable<INode> GetChildren()
        {
            var items = ItemReferrer.GetClonedItems(this.Context.Item);
            return items.Select(item => new ItemNode
            {
                Context = new ReferenceContext { Item = item },
                DisplayName = item.DisplayName
            });
        }
    }
}
