namespace Referenception.Common
{
    using System.Collections.Generic;
    using System.Linq;

    using Referenception.Core;

    using Sitecore.Data.Fields;
    using Sitecore.Data.Managers;

    public class FieldReferencesProvider : ReferenceProviderBase
    {
        public FieldReferencesProvider(ReferenceContext context) : base(context)
        {
        }

        public override IEnumerable<INode> GetChildren()
        {
            foreach (var itemLink in this.Context.Item.Links.GetAllLinks(false, false))
            {
                var item = this.Context.Item.Database.GetItem(itemLink.TargetPath);
                yield return new FieldNode(this.Context)
                {
                    DisplayName = item.Name
                };
            }


            //foreach (Field field in this.Context.Item.Fields.Where(f => f.Type == "Droplink"))
            //{
            //    var item = this.Context.Item.Database.GetItem(field.Value);
            //    yield return new FieldNode(this.Context)
            //    {
            //        DisplayName = string.Format("{0} ({1})", item.Name, item.ID)
            //    };
            //}



            //var item = this.Context.Item;
            //var template = TemplateManager.GetTemplate(item);
            //foreach (var templateField in template.GetFields(false))
            //{


            //}
        }
    }
}
