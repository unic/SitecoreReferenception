using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Referenception.Core.Data
{
    public class DataTable
    {
        public DataTable()
        {
            this.Rows = new List<DataRow>();
        }
        
        public string Title { get; set; }

        public List<DataRow> Rows { get; private set; } 
    }
}
