using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
namespace SCIMConnectorPOC
{
    public class SchemaClass
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        [JsonProperty(PropertyName = "attributes")]
        public SchemaAttribute[] SchemaAttributes { get; set; }
        public Meta1 meta { get; set; }
        public string schema { get; set; }
        public string endpoint { get; set; }
        public string type { get; set; }

        public SchemaAttribute GetAttribute(string name)
        {
            foreach (SchemaAttribute attr in SchemaAttributes)
                if (System.String.Compare(attr.name, name, System.StringComparison.OrdinalIgnoreCase) == 0) return attr;

            return null;
        }

        public class Meta1
        {
            public string resourceType { get; set; }
            public string location { get; set; }
        }
    }
}
