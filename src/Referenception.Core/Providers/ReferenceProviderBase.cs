namespace Referenception.Core.Providers
{
    using System.Collections.Generic;
    using System.Data;
    using Sitecore.Data;
    using Sitecore.Data.Items;

    /// <summary>
    /// The base class implementation of the reference provider.
    /// </summary>
    public abstract class ReferenceProviderBase
    {
        /// <summary>
        /// The tool tip column name
        /// </summary>
        public const string ToolTipColumnName = "Tooltip";

        /// <summary>
        /// The templates
        /// </summary>
        private readonly List<string> templates = new List<string>();

        /// <summary>
        /// Gets the templates.
        /// </summary>
        /// <value>
        /// The templates.
        /// </value>
        public List<string> Templates
        {
            get
            {
                return this.templates;
            }
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets the link item identifier.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <returns>The link item ID</returns>
        public virtual ID GetLinkItemId(DataRow row)
        {
            return ID.Null;
        }

        /// <summary>
        /// Gets the tooltip.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <returns>The tooltip key-value collection</returns>
        public virtual IDictionary<string, string> GetTooltip(DataRow row)
        {
            return null;
        }

        /// <summary>
        /// Gets the data table.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>The data table</returns>
        public abstract DataTable GetData(Item item);
    }
}
