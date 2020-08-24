using System;
using Newtonsoft.Json;
namespace SCIMConnectorPOC.Entities
{

    // //public Resource[] Resources { get; set; }
    public class Userobject
    {
        public int totalResults { get; set; }
        public int itemsPerPage { get; set; }
        public string[] schemas { get; set; }
        [JsonProperty(PropertyName = "Resources")]
        public ScimUser[] ScimUsers { get; set; }
    }

    public class ScimUser
    {
        public string[] schemas { get; set; }
        public string id { get; set; }
        public string userName { get; set; }
        public Name name { get; set; }
        public string displayName { get; set; }
        public string nickName { get; set; }
        public Email[] emails { get; set; }
        public Address[] addresses { get; set; }
        public Photo[] photos { get; set; }
        public string userType { get; set; }
        public string preferredLanguage { get; set; }
        public string emailEncodingKey { get; set; }
        public string locale { get; set; }
        public string timezone { get; set; }
        public bool active { get; set; }
        public Entitlement[] entitlements { get; set; }
        public UrnIetfParamsScimSchemasExtensionEnterprise20User urnietfparamsscimschemasextensionenterprise20User { get; set; }
        public Meta meta { get; set; }
        public Phonenumber[] phoneNumbers { get; set; }
    }

    public class Name
    {
        public string formatted { get; set; }
        public string familyName { get; set; }
        public string givenName { get; set; }
    }

    public class UrnIetfParamsScimSchemasExtensionEnterprise20User
    {
        public string organization { get; set; }
    }

    public class Meta
    {
        public DateTime created { get; set; }
        public DateTime lastModified { get; set; }
        public string location { get; set; }
        public string resourceType { get; set; }
        public string version { get; set; }
    }

    public class Email
    {
        public string type { get; set; }
        public bool primary { get; set; }
        public string value { get; set; }
    }

    public class Address
    {
        public string type { get; set; }
        public bool primary { get; set; }
        public string streetAddress { get; set; }
        public string locality { get; set; }
        public string region { get; set; }
        public string postalCode { get; set; }
        public string country { get; set; }
        public string formatted { get; set; }
    }

    public class Photo
    {
        public string type { get; set; }
        public string value { get; set; }
    }

    public class Entitlement
    {
        public string value { get; set; }
        public string _ref { get; set; }
        public string display { get; set; }
        public string type { get; set; }
        public bool primary { get; set; }
    }

    public class Phonenumber
    {
        public string type { get; set; }
        public string value { get; set; }
    }

}
