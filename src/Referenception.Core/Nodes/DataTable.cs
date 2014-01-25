namespace Referenception.Core.Nodes
{
    using System.Collections.Generic;

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
