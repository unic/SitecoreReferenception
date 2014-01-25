namespace Referenception.Core.Nodes
{
    using Sitecore.Data.Fields;
    using Sitecore.Data.Items;

    public class ReferenceContext
    {
        public Item Item { get; set; }

        public Field Field { get; set; }
    }
}
