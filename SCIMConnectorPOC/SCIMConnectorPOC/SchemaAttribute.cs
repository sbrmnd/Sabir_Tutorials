using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCIMConnectorPOC
{
    public class SchemaAttribute
    {
        public string name { get; set; }
        public string type { get; set; }
        public bool multiValued { get; set; }
        public string description { get; set; }
        public string mutability { get; set; }
        public bool required { get; set; }
        public bool caseExact { get; set; }
        public string uniqueness { get; set; }
        public Subattribute[] subAttributes { get; set; }
    }

    public class Subattribute
    {
        public string name { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public string mutability { get; set; }
        public bool required { get; set; }
        public bool caseExact { get; set; }
        public Canonicalvalue[] canonicalValues { get; set; }
    }

    public class Canonicalvalue
    {
        public string value { get; set; }
    }
}
