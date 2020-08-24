using Newtonsoft.Json;

namespace SCIMConnectorPOC
{
    public class Schemaobject
    {
        public int totalResults { get; set; }
        public int itemsPerPage { get; set; }
        public int startIndex { get; set; }
        public string[] schemas { get; set; }
        [JsonProperty(PropertyName = "Resources")]
        public SchemaClass[] SchemaClasses { get; set; }
        public Meta meta { get; set; }
    }

    public class Meta
    {
        public string location { get; set; }
        public string resourceType { get; set; }
    }

    //public class SchemaClass
    //{
    //    public string id { get; set; }
    //    public string name { get; set; }
    //    public string description { get; set; }
    //    [JsonProperty(PropertyName = "attributes")]
    //    public SchemaAttribute[] SchemaAttributes { get; set; }
    //    public Meta1 meta { get; set; }
    //    public string schema { get; set; }
    //    public string endpoint { get; set; }
    //    public string type { get; set; }

    //    public SchemaAttribute GetAttribute(string name)
    //    {
    //        foreach (SchemaAttribute attr in SchemaAttributes)
    //            if (System.String.Compare(attr.name, name, System.StringComparison.OrdinalIgnoreCase) == 0) return attr;

    //        return null;
    //    }
    //}

    //public class Meta1
    //{
    //    public string resourceType { get; set; }
    //    public string location { get; set; }
    //}

    //public class SchemaAttribute
    //{
    //    public string name { get; set; }
    //    public string type { get; set; }
    //    public bool multiValued { get; set; }
    //    public string description { get; set; }
    //    public string mutability { get; set; }
    //    public bool required { get; set; }
    //    public bool caseExact { get; set; }
    //    public string uniqueness { get; set; }
    //    public Subattribute[] subAttributes { get; set; }
    //}

    //public class Subattribute
    //{
    //    public string name { get; set; }
    //    public string type { get; set; }
    //    public string description { get; set; }
    //    public string mutability { get; set; }
    //    public bool required { get; set; }
    //    public bool caseExact { get; set; }
    //    public Canonicalvalue[] canonicalValues { get; set; }
    //}

    //public class Canonicalvalue
    //{
    //    public string value { get; set; }
    //}
}