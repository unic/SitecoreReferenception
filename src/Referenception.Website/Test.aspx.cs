using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Referenception.Website
{
    using System.Xml;

    using Referenception.Core;
    using Referenception.Core.Configuration;
    using Referenception.Core.Nodes;
    using Referenception.Core.Providers;

    using Sitecore.Data.Items;

    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var item = Sitecore.Context.Database.GetItem("/sitecore/content/Home");
            var providers = ConfigurationFactory.GetProviders(item);

            foreach (var provider in providers)
            {
                this.OutputNode(provider, item);
            }
        }

        private void OutputNode(IReferenceProvider provider, Item item)
        {
            Response.Write(string.Format("<h1>{0}</h1>", provider.Title));
            foreach (var table in provider.GetData(item))
            {
                Response.Write(string.Format("<h2>{0}</h2>", table.Title));

                foreach (var row in table.Rows)
                {
                    Response.Write(string.Format("name: {0}", row.DisplayName));
                }
            }
        }
    }
}