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

    public class UsageReferencesProvider : ReferenceProviderBase
    {
        public override IEnumerable<INode> GetChildren()
        {
            var items = this.Context.Item.GetLinkedItems();
            foreach (var item in items)
            {
                var node = new ItemNode
                           {
                               Context = new ReferenceContext { Item = item },
                               DisplayName = item.DisplayName
                           };

                yield return node;
            }
        }
    }
}
