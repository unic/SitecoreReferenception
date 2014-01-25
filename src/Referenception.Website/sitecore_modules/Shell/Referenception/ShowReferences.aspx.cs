using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Referenception.Website.sitecore_modules.Shell.Referenception
{
    using Sitecore.Configuration;
    using Sitecore.Data;
    using Sitecore.Data.Items;
    using Sitecore.Data.Managers;
    using Sitecore.Globalization;

    public partial class ShowReferences : System.Web.UI.Page
    {
        private Item item;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // get querystring params
                var language = Language.Parse(Sitecore.Web.WebUtil.GetSafeQueryString("la"));
                var database = Factory.GetDatabase(Sitecore.Web.WebUtil.GetSafeQueryString("db"));
                var version = Version.Parse(Sitecore.Web.WebUtil.GetSafeQueryString("v"));
                var id = HttpUtility.UrlDecode(Sitecore.Web.WebUtil.GetSafeQueryString("id"));

                // get the item
                this.item = ItemManager.GetItem(id, language, version, database);
                if (this.item == null) throw new Exception("No item found");

                // load the providers
                var providers = Core.Configuration.ConfigurationFactory.GetProviders(this.item).ToList();
                if (!providers.Any())
                {
                    panNoProviders.Visible = true;
                    return;
                }

                plhData.Visible = true;
                repProviders.ItemDataBound += Providers_OnItemDataBound;
                repProviders.DataSource = providers;
                repProviders.DataBind();
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error("Could not load item references", ex, this);
                panError.Visible = true;
                plhData.Visible = false;
            }
        }

        protected string FirstCssClass(int index)
        {
            return index == 0 ? "in" : string.Empty;
        }

        private void Providers_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var item = e.Item;
            if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
            {
                var provider = (Core.Providers.IReferenceProvider)item.DataItem;
                var rows = provider.GetData(this.item).Rows;

                ((Literal)item.FindControl("litTitle")).Text = provider.Title;
                ((Literal)item.FindControl("litRowCount")).Text = rows.Count.ToString();
                ((PlaceHolder)item.FindControl("plhFieldColumn")).Visible = provider.HasFieldColumn;

                var rowsRepeater = (Repeater)item.FindControl("repRows");
                rowsRepeater.ItemDataBound += this.Rows_OnItemDataBound;
                rowsRepeater.DataSource = rows;
                rowsRepeater.DataBind();
            }
        }

        private void Rows_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var item = e.Item;
            if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
            {
                var dataRow = (Core.Nodes.DataRow)item.DataItem;

                ((Literal)item.FindControl("litFieldName")).Text = dataRow.FieldName;
                ((Literal)item.FindControl("litId")).Text = dataRow.Id;
                ((Literal)item.FindControl("litDisplayName")).Text = dataRow.DisplayName;
                ((Literal)item.FindControl("litPath")).Text = dataRow.ItemPath;
                ((PlaceHolder)item.FindControl("plhFieldColumn")).Visible = !string.IsNullOrWhiteSpace(dataRow.FieldName);
            }
        }
    }
}