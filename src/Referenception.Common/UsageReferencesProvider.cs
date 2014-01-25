using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Referenception.Common
{
    using Referenception.Core;
    using Referenception.Core.Nodes;
    using Referenception.Core.Utilities;

    public class UsageReferencesProvider : ReferenceProviderBase
    {
        public override IEnumerable<INode> GetChildren()
        {
            var items = ItemReferrer.GetLinkedItems(this.Context.Item);
            return items.Select(item => new ItemNode
                                        {
                                            Context = new ReferenceContext { Item = item },
                                            DisplayName = item.DisplayName
                                        });
        }
    }
}
