using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SCIMConnectorPOC
{
    public class AuthToken
    {
        public AuthToken() { }

        #region
        //string GetAuthToken()
        //{
        //    string bearerToken = string.Empty;

        //    using (HttpClient httpClient = new HttpClient())
        //    {
        //        httpClient.BaseAddress = new Uri(connectionParam.ClientsTokenEndpoint);
        //        httpClient.DefaultRequestHeaders.Accept.Clear();
        //        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        List<KeyValuePair<string, string>> postData = new List<KeyValuePair<string, string>>();
        //        postData.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
        //        postData.Add(new KeyValuePair<string, string>("client_id", connectionParam.ClientId));
        //        postData.Add(new KeyValuePair<string, string>("client_secret", TDESEncryption.decryptString(connectionParam.ClientSecret)));
        //        FormUrlEncodedContent content = new FormUrlEncodedContent(postData);

        //        try
        //        {
        //            HttpResponseMessage response = await httpClient.PostAsync("token", content).ConfigureAwait(continueOnCapturedContext: false);
        //            string jsonString = await response.Content.ReadAsStringAsync();
        //            object responseData = JsonConvert.DeserializeObject(jsonString);
        //            bearerToken = ((dynamic)responseData).access_token;
        //        }
        //        catch (Exception ex)
        //        {
        //            ArsConfigLog.WriteInformation("SetStarlingConnectAction::OpenConnectionAsync- Exception" + ex.Message);
        //        }
        //    }

        //    return bearerToken;

        //}
        //string bearerToken = string.Empty;


        #endregion
    }

    public class TokenParameters
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string ClientsTokenEndpoint { get; set; }
        public bool? IsStarlingEnabled { get; set; } = false;
        public string DN { get; set; }
        public string ProductInstance { get; set; }
        public int? StarlingInstanceReg { get; set; }
        public string StarlingSubscriptionId { get; set; }

        private const string clientSecretMask = "[Client secret]";

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(String.Format("   ClientId = '{0}'", EscapeBraces(ClientId)));
            if (!string.IsNullOrEmpty(ClientSecret)) sb.AppendLine(String.Format("   ClientSecret = '{0}'", clientSecretMask));
            else sb.AppendLine(String.Format("   ClientSecret = '{0}'", String.Empty));
            sb.AppendLine(String.Format("   ClientsTokenEndpoint = '{0}'", ClientsTokenEndpoint));
            sb.AppendLine(String.Format("   IsStarlingEnabled = '{0}'", IsStarlingEnabled));
            sb.AppendLine(String.Format("   ProductInstance = '{0}'", ProductInstance));
            sb.AppendLine(String.Format("   StarlingSubscriptionId = '{0}'", StarlingSubscriptionId));
            sb.AppendLine(String.Format("   DN = '{0}'", EscapeBraces(DN)));
            return sb.ToString();
        }
        //public virtual void SetProperties(PSMemberInfoCollection<PSPropertyInfo> propertyCollection)
        //{

        //    ClientId = Convert.ToString(propertyCollection["ClientId"].Value);

        //    ClientSecret = Convert.ToString(propertyCollection["ClientSecret"].Value);
        //    ClientsTokenEndpoint = Convert.ToString(propertyCollection["ClientsTokenEndpoint"].Value);
        //    DN = Convert.ToString(propertyCollection["DN"].Value);
        //    ProductInstance = Convert.ToString(propertyCollection["ProductInstance"].Value);
        //    StarlingInstanceReg = Convert.ToInt32(propertyCollection["StarlingInstanceReg"].Value);
        //    StarlingSubscriptionId = Convert.ToString(propertyCollection["StarlingSubscriptionId"].Value);
        //    IsStarlingEnabled = Convert.ToBoolean(propertyCollection["IsStarlingEnabled"].Value);
        //}
        public  string EscapeBraces(string target)
        {
            return (target != null) ? target.Replace("{", "{{").Replace("}", "}}") : null;
        }
    }

}
