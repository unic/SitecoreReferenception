using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
