using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Referenception.Core.Data
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
