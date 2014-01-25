namespace Referenception.Website.sitecore.shell.client.referenception.showreferences
{
    using System.Web.UI.WebControls;

    using Sitecore.Mvc.Presentation;
    using Sitecore.Web;
    using Sitecore.Web.PageCodes;

    public class ShowReferences : PageCodeBase 
    {
        public Rendering TreeView { get; set; }

        public override void Initialize()
        {
            this.TreeView.Parameters["RootItem"] = WebUtil.GetQueryString("fo");
        }
    }
}