using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Referenception.Core.Providers
{
    using Referenception.Core.Data;

    public interface IReferenceProvider
    {
        string Title { get; set; }

        IEnumerable<Table> GetData();
    }
}
