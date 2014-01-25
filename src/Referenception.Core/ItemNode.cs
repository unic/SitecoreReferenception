using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Referenception.Core
{
    public class ItemNode : NodeBase
    {
        public ItemNode(ReferenceContext context) : base(context)
        {
        }

        public override IEnumerable<INode> GetChildren()
        {
            //yield return new CloneReferenceProvider();
            //yield return new UsageReferenceProvider();

            return null;
        }
    }
}
