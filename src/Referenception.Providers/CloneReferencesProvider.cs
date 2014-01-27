namespace Referenception.Providers
{
    using System.Collections.Generic;
    using System.Data;
    using Referenception.Core.Providers;
    using Referenception.Core.Utilities;
    using Sitecore.Data;
    using Sitecore.Data.Items;
    using Sitecore.Globalization;

    /// <summary>
    /// The clone references provides.
    /// </summary>
    public class CloneReferencesProvider : ReferenceProviderBase
    {
        /// <summary>
        /// Gets the data table.
        /// </summary>
        /// <param name="sourceItem">The source item.</param>
        /// <returns>The data table</returns>
        public override DataTable GetData(Item sourceItem)
        {
            var table = new DataTable();

            table.Columns.Add(Translate.Text("Id"), typeof(ID));
            table.Columns.Add(Translate.Text("Display name"), typeof(string));
            table.Columns.Add(Translate.Text("Item path"), typeof(string));
            table.Columns.Add(ReferenceProviderBase.ToolTipColumnName, typeof(IDictionary<string, string>));

            foreach (var item in ItemReferrer.GetClonedItems(sourceItem))
            {
                table.Rows.Add(item.ID, item.DisplayName, item.Paths.FullPath, TooltipUtil.GetItemTooltip(item));
            }

            return table;
        }

        /// <summary>
        /// Gets the link item identifier.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <returns>
        /// The link item ID
        /// </returns>
        public override ID GetLinkItemId(DataRow row)
        {
            return (ID)row[Translate.Text("Id")];
        }

        /// <summary>
        /// Gets the tooltip.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <returns>
        /// The tooltip key-value collection
        /// </returns>
        public override IDictionary<string, string> GetTooltip(DataRow row)
        {
            return (IDictionary<string, string>)row[ToolTipColumnName];
        }
    }
}
