namespace Referenception.Website.sitecore.admin
{
    using System;

    using Referenception.Common;
    using Referenception.Core;

    using Sitecore.Configuration;
    using Sitecore.Diagnostics;

    public partial class Tests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Sitecore.Context.IsUnitTesting = true;
            var database = Factory.GetDatabase("master");


            var context = new ReferenceContext();
            context.Item = database.GetItem("{110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9}");
            var provider = new FieldReferencesProvider(context);
            foreach (var child in provider.GetChildren())
            {
                lblText.Text += child.DisplayName + "<br/>";
            }
        }
    }
}