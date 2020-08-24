using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using SCIMConnectorPOC.Properties;
using System.Reflection;

using SCIMConnectorPOC.Entities;

namespace SCIMConnectorPOC
{
    public class Token
    {
        public string access_token { get; set; }
        public string instance_url { get; set; }
        public string id { get; set; }
        public string tokey_type { get; set; }
        public string issued_at { get; set; }
        public string signature { get; set; }

    }

    public class SaleForeSCIM
    {
        public SaleForeSCIM()
        {
            var scimSchemaUrl = "https://ap15.salesforce.com/services/scim/v2/Schemas";
            //var scimUrl = "https://ap15.salesforce.com/services/scim/v2/Users";
            var username = "saswat.sahu@quest.com";
            var password = "salesforce12";
            var token = "FnkqhUfr4g6UBX3U3nun9JmLn";
            var combinedPassword = password + token;
            var token_endpoint = "https://login.salesforce.com/services/oauth2/token";
            var client_id = "3MVG9G9pzCUSkzZsHNUacmGQNgdM0RZwi55TlOasgnvGmhE2O3cZBMHcc6eprq83sONM37IpJsASJ4dOOyjix";
            var client_secret = "D0270AF4848E253D73696F079DC2CD06E92A69C8A378D569462C1FC2E0ADF768";
            var grant_type = "password";
            var bearerToken = GetOAuthToken(token_endpoint, grant_type, username, combinedPassword, client_id, client_secret);
            var client = GetClient(bearerToken.access_token);

            //Scim Schema with Schema
            //GetSchemaJson(scimSchemaUrl, client);

            //Default Schema.
            GetSchemaJson("", client);

            //User
            //var result = GetUsersJson(scimUrl, client);

        }
        public SaleForeSCIM(string scimUrl, string username, string password,string token)
        {
            //var scimUrl = "https://ap15.salesforce.com/services/scim/v2/Users";
            //var username = "saswat.sahu@quest.com";
           // var password = "salesforce12";
            //var token = "FnkqhUfr4g6UBX3U3nun9JmLn";
            var combinedPassword = password + token;
            var token_endpoint = "https://login.salesforce.com/services/oauth2/token";
            var client_id = "3MVG9G9pzCUSkzZsHNUacmGQNgdM0RZwi55TlOasgnvGmhE2O3cZBMHcc6eprq83sONM37IpJsASJ4dOOyjix";
            var client_secret = "D0270AF4848E253D73696F079DC2CD06E92A69C8A378D569462C1FC2E0ADF768";
            var grant_type = "password";
            var bearerToken = GetOAuthToken(token_endpoint, grant_type, username, combinedPassword, client_id, client_secret);
            var client = GetClient(bearerToken.access_token);
            var result = GetUsersJson(scimUrl, client);

        }
        public  Token GetOAuthToken(string tokenUrl, string grantType, string username, string password, string cliendId, string clientSecret)
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri(tokenUrl)
            };

            var form = new Dictionary<string, string>
                {
                    {"grant_type", grantType},
                    { "username",username},
                    {"password", password },
                    {"client_id", cliendId},
                    {"client_secret", clientSecret},
                };
            HttpResponseMessage tokenResponse = client.PostAsync(tokenUrl, new FormUrlEncodedContent(form)).Result;
            var jsonContent = tokenResponse.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<Token>(jsonContent);
        }

        public  HttpClient GetClient(string token)
        {
            var authValue = new AuthenticationHeaderValue("Bearer", token);

            var client = new HttpClient()
            {
                DefaultRequestHeaders = { Authorization = authValue }
            };
            return client;
        }

        public string GetUsersJson(string scimurl, HttpClient client)
        {
            try
            {
                var response = client.GetAsync(scimurl).Result;
                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = response.Content.ReadAsStringAsync().Result;
                    Entities.Userobject userobjets = JsonConvert.DeserializeObject<Entities.Userobject>(jsonContent);
                }
            }
            finally
            {
                if (client != null)
                    client.Dispose();
            }

            return null;
        }

        //public string GetUsersJson(string scimurl, HttpClient client)
        //{
        //    try
        //    {
        //        var response = client.GetAsync(scimurl).Result;
        //        if (response.IsSuccessStatusCode)
        //        {
        //            return response.Content.ReadAsStringAsync().Result;
        //        }
        //    }
        //    finally
        //    {
        //        if (client != null)
        //            client.Dispose();
        //    }

        //    return null;
        //}

        public void GetSchemaJson(string scimurl, HttpClient client)
        {
            if(string.IsNullOrEmpty(scimurl))
            {
                string str = Encoding.UTF8.GetString(InternalReources.DefaultSchema);



                string viaStreamReader;
                using (StreamReader reader = new StreamReader
                       (new MemoryStream(InternalReources.DefaultSchema), Encoding.UTF8))
                {
                    viaStreamReader = reader.ReadToEnd();
                    Schemaobject rot = JsonConvert.DeserializeObject<Schemaobject>(viaStreamReader);
                }



            }
            try
            {
                var response = client.GetAsync(scimurl).Result;
                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = response.Content.ReadAsStringAsync().Result;


                    Schemaobject rot = JsonConvert.DeserializeObject<Schemaobject>(jsonContent);

                    Dictionary<string, List<SchemaAttribute>> scimAttr = new Dictionary<string, List<SchemaAttribute>>();

                    //List<SchemaClass> starlingConnectSchema = JsonConvert.DeserializeObject<List<SchemaClass>>(jsonContent);
                    //var schemaClass = JsonConvert.DeserializeObject<SchemaClass>(jsonContent);

                    //var resultA = JsonConvert.DeserializeObject<SchemaClass[]>(jsonContent);


                    foreach (var vclass in rot.SchemaClasses)
                    {
                        scimAttr.Add(vclass.name, new List<SchemaAttribute>(vclass.SchemaAttributes));
                    }

                    
                }
            }
            finally
            {
                if (client != null)
                    client.Dispose();
            }

           
        }


    }
}
