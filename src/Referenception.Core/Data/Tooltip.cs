namespace Referenception.Core.Data
{
    using System.Collections.Generic;

    public class Tooltip
    {
        public string DisplayName { get; set; }
        public string Id { get; set; }
        public string TemplateName { get; set; }
        public string TemplateId { get; set; }
        public string Created { get; set; }
        public string Updated { get; set; }
        public string Revision { get; set; }
        public IEnumerable<string> Languages { get; set; }
        public string Versions { get; set; }
    }
}