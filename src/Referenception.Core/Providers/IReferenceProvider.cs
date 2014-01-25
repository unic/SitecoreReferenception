namespace Referenception.Core.Providers
{
    using Referenception.Core.Nodes;
    using Sitecore.Data.Items;

    public interface IReferenceProvider
    {
        string Title { get; set; }

        DataTable GetData(Item item);

        bool HasFieldColumn { get; set; }
    }
}
