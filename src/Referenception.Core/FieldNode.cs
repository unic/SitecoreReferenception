using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Referenception.Core
{
    public class FieldNode : NodeBase
    {
        public FieldNode(ReferenceContext context) : base(context)
        {
        }

        public override IEnumerable<INode> GetChildren()
        {
            throw new NotImplementedException();
        }
    }
}
