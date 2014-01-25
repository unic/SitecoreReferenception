namespace Referenception.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Referenception.Core.Data;
    using Referenception.Core.Extensions;
    using Referenception.Core.Nodes;
    using Referenception.Core.Providers;

    public class FieldReferencesProvider : ReferenceProviderBase
    {
        private readonly List<string> fieldTypes = new List<string>();

        public List<string> FieldTypes
        {
            get
            {
                return this.fieldTypes;
            }
        }

        //public override IEnumerable<INode> GetChildren()
        //{
        //    var fields = this.Context.Item.Fields
        //        .Where(field => this.FieldTypes.Any(type => type == field.Type))
        //        .Where(field => !field.IsStandardTemplateField());

        //    return fields.Select(field => new FieldNode
        //                                      {
        //                                          Context = new ReferenceContext { Item = this.Context.Item, Field = field },
        //                                          DisplayName = field.DisplayName
        //                                      });
        //}

        public override IEnumerable<DataTable> GetData()
        {
            return Enumerable.Empty<DataTable>();
        }
    }
}
