namespace Referenception.Core.Commands
{
    using System;
    using System.Globalization;
    using Sitecore;
    using Sitecore.Globalization;
    using Sitecore.Resources;
    using Sitecore.Shell.Framework.Commands;
    using Sitecore.Text;
    using Sitecore.Web.UI.Framework.Scripts;
    using Sitecore.Web.UI.Sheer;

    /// <summary>
    /// Opens a new content editor tab with the references of the current item
    /// </summary>
    public class ShowReferences : Command
    {
        /// <summary>
        /// The application URL
        /// </summary>
        private UrlString applicationUrl;

        /// <summary>
        /// Executes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Execute(CommandContext context)
        {
            if (context == null || context.Parameters == null || context.Parameters.Count <= 0) return;
            this.applicationUrl = new UrlString(Sitecore.Configuration.Settings.GetSetting("Referenception.ApplicationUrl", string.Empty));
            context.Items[0].Uri.AddToUrlString(this.applicationUrl);
            SheerResponse.Eval(new ShowEditorTab()
            {
                Command = "contenteditor:launchblanktab",
                Header = Translate.Text("References"),
                Icon = Images.GetThemedImageSource("Applications/16x16/text_view.png"),
                Url = this.applicationUrl.ToString(),
                Id = new Random().Next(0, 99999999).ToString(CultureInfo.InvariantCulture),
                Closeable = true,
                Activate = true
            }.ToString());
        }
    }
}
