namespace Referenception.Core.Nodes
{
    using System.Globalization;
    using System.Linq;
    using Referenception.Core.Data;
    using Sitecore.Data.Items;

    public class DataRow
    {
        public Item Item { get; set; }
        
        public string DisplayName { get; set; }

        public string Id { get; set; }

        public string TemplateName { get; set; }

        public string ItemPath { get; set; }
		
        public virtual Tooltip GetTooltip()
        {
            return new Tooltip
                       {
                           DisplayName = this.DisplayName,
                           Id = this.Id,
                           TemplateName = this.TemplateName,
                           TemplateId = this.Item.TemplateID.ToString(),
                           Created = this.Item.Statistics.Created.ToLongTimeString(),
                           Updated = this.Item.Statistics.Updated.ToLongTimeString(),
                           Revision = this.Item.Statistics.Revision,
                           Languages = this.Item.Languages.Select(l => l.ToString()),
                           Versions = this.Item.Versions.Count.ToString(CultureInfo.InvariantCulture)
                       };
        }
    }
}
