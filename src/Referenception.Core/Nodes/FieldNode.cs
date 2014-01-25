namespace Referenception.Core.Nodes
{
    using System.Collections.Generic;

    public class FieldNode : NodeBase
    {
        public override IEnumerable<INode> GetChildren()
        {
            if (this.Context.Item != null && this.Context.Field != null)
            {
                foreach (var id in this.Context.Field.Value.Split('|'))
                {
                    var item = this.Context.Item.Database.GetItem(id);
                    if (item == null) continue;

                    var context = new ReferenceContext { Item = item };
                    yield return new ItemNode { Context = context };
                }
            }
        }
    }
}