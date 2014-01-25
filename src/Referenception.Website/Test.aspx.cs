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

    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var context = new ReferenceContext { Item = Sitecore.Context.Database.GetItem("/sitecore/content/Home") };
            var itemNode = new ItemNode { Context = context };

            Response.Write(itemNode.Context.Item.DisplayName + "<br />");

            foreach (var child in itemNode.GetChildren())
            {
                Response.Write(" - " + child.ToString() + "<br />");
            }
        }
    }
}