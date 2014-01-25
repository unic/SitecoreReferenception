namespace Referenception.Core.Nodes
{
    using Sitecore.Data.Items;

    public class DataRow
    {
        public Item Item { get; set; }
        
        public string DisplayName { get; set; }

        public string Id { get; set; }

        public string TemplateName { get; set; }

        public string ItemPath { get; set; }
    }
}
