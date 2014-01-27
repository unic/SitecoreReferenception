using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

// ReSharper disable once CheckNamespace
namespace Referenception.Website.SitecoreModules.Shell.Referenception
{
    using System.Data;
    using Core.Providers;
    using Sitecore.Configuration;
    using Sitecore.Data;
    using Sitecore.Data.Items;
    using Sitecore.Data.Managers;
    using Sitecore.Globalization;
    using Sitecore.Shell.Web.UI;

    /// <summary>
    /// Shows all references of all configured providers
    /// </summary>
    public partial class ShowReferences : SecurePage
    {
        /// <summary>
        /// The item
        /// </summary>
        private Item item;

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.Exception">No item found</exception>
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

                this.litTitle.Text = string.Format("{0} {1}", ThemeManager.GetIconImage(this.item, 32, 32, string.Empty, string.Empty), this.item.DisplayName);

                // load the providers
                var providers = Core.Configuration.ConfigurationFactory.GetProviders(this.item).ToList();
                if (!providers.Any())
                {
                    this.panNoProviders.Visible = true;
                    return;
                }

                this.plhData.Visible = true;
                this.repProviders.ItemDataBound += this.Providers_OnItemDataBound;
                this.repProviders.DataSource = providers;
                this.repProviders.DataBind();
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error("Could not load item references", ex, this);
                this.panError.Visible = true;
                this.plhData.Visible = false;
            }
        }

        /// <summary>
        /// Returns the CSS class based on the index position
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>The CSS class</returns>
        protected string FirstCssClass(int index)
        {
            return index == 0 ? "in" : string.Empty;
        }

        /// <summary>
        /// Gets the tooltip identifier.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>The unique tooltip identifier</returns>
        protected string GetTooltipId(RepeaterItem item)
        {
            return string.Format("{0}_{1}", ((RepeaterItem)item.Parent.Parent.Parent).ItemIndex, item.ItemIndex);
        }

        /// <summary>
        /// Determines whether the specified item has tooltip.
        /// </summary>
        /// <param name="repeaterItem">The repeater item.</param>
        /// <returns>
        /// The evaluation result
        /// </returns>
        protected bool HasTooltip(RepeaterItem repeaterItem)
        {
            return this.GetProvider(repeaterItem).GetTooltip((DataRow)repeaterItem.DataItem) != null;
        }

        /// <summary>
        /// Determines whether the specified item has tooltip.
        /// </summary>
        /// <param name="repeaterItem">The repeater item.</param>
        /// <returns>
        /// The evaluation result
        /// </returns>
        protected bool HasItemLink(RepeaterItem repeaterItem)
        {
            return !this.GetProvider(repeaterItem).GetLinkItemId((DataRow)repeaterItem.DataItem).IsNull;
        }

        /// <summary>
        /// Gets the link item identifier.
        /// </summary>
        /// <param name="repeaterItem">The repeater item.</param>
        /// <returns>The link item id</returns>
        protected string GetLinkItemId(RepeaterItem repeaterItem)
        {
            return this.GetProvider(repeaterItem).GetLinkItemId((DataRow)repeaterItem.DataItem).ToString();
        }

        /// <summary>
        /// Gets the provider.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>The provider</returns>
        private ReferenceProviderBase GetProvider(RepeaterItem item)
        {
            return ((RepeaterItem)item.Parent.Parent.Parent).DataItem as ReferenceProviderBase;
        }

        /// <summary>
        /// Handles the OnItemDataBound event of the Providers control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RepeaterItemEventArgs"/> instance containing the event data.</param>
        private void Providers_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var repeaterItem = e.Item;
            if (repeaterItem.ItemType == ListItemType.Item || repeaterItem.ItemType == ListItemType.AlternatingItem)
            {
                var provider = (ReferenceProviderBase)repeaterItem.DataItem;
                var dataTable = provider.GetData(this.item);
                var rowCount = dataTable.Rows.Count;

                ((Literal)repeaterItem.FindControl("litTitle")).Text = provider.Title;
                ((Literal)repeaterItem.FindControl("litRowCount")).Text = rowCount.ToString();

                if (rowCount > 0)
                {
                    var repColumns = (Repeater)repeaterItem.FindControl("repColumns");
                    repColumns.DataSource = dataTable.Columns.Cast<DataColumn>()
                        .Where(column => column.ColumnName != ReferenceProviderBase.ToolTipColumnName)
                        .Select(column => column.ColumnName);
                    repColumns.DataBind();

                    var rowsRepeater = (Repeater)repeaterItem.FindControl("repRows");
                    rowsRepeater.ItemDataBound += this.Rows_OnItemDataBound;
                    rowsRepeater.DataSource = dataTable.Rows;
                    rowsRepeater.DataBind();
                    return;
                }

                repeaterItem.FindControl("panBody").Visible = false;
                repeaterItem.FindControl("panNoReferences").Visible = true;
            }
        }

        /// <summary>
        /// Handles the OnItemDataBound event of the Rows control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RepeaterItemEventArgs"/> instance containing the event data.</param>
        private void Rows_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var repeaterItem = e.Item;
            if (repeaterItem.ItemType == ListItemType.Item || repeaterItem.ItemType == ListItemType.AlternatingItem)
            {
                var dataRow = (DataRow)repeaterItem.DataItem;

                var repColumns = (Repeater)repeaterItem.FindControl("repColumns");
                repColumns.DataSource = dataRow.ItemArray.Where(column => column as IDictionary<string, string> == null);
                repColumns.DataBind();

                var tooltip = this.GetProvider(repeaterItem).GetTooltip(dataRow);
                if (tooltip != null)
                {
                    var repTooltip = (Repeater)repeaterItem.FindControl("repTooltip");
                    repTooltip.DataSource = tooltip;
                    repTooltip.DataBind();
                }
            }
        }
    }
}