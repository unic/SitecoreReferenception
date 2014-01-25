using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Referenception.Core.Utilities
{
    using Sitecore.Data.Items;
    using Sitecore.Globalization;

    public static class TooltipUtil
    {
        public static IDictionary<string, string> GetItemTooltip(Item item)
        {
            var dictionary = new Dictionary<string, string>();
            dictionary.Add(Translate.Text("Template name"), item.TemplateName);
            dictionary.Add(Translate.Text("Template id"), item.TemplateID.ToString());
            dictionary.Add(Translate.Text("Created date"), item.Statistics.Created.ToString());
            dictionary.Add(Translate.Text("Updated date"), item.Statistics.Updated.ToString());
            dictionary.Add(Translate.Text("Revision"), item.Statistics.Revision);

            return dictionary;
        }
    }
}
