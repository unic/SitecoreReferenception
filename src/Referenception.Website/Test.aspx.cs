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
            var item = Sitecore.Context.Database.GetItem("/sitecore/content/Home");
            var context = new ReferenceContext { Item = item };
            var itemNode = new ItemNode { Context = context, DisplayName = item.DisplayName };

            this.OutputNode(itemNode, 1);
        }

        private void OutputNode(INode node, int spaces)
        {
            if (spaces > 10) return;
            
            for (int i = 0; i < spaces; i++)
            {
                Response.Write("-");
            }

            Response.Write(node.DisplayName + "<br />");

            foreach (var childNode in node.GetChildren())
            {
                this.OutputNode(childNode, spaces+1);
            }
        }
    }
}