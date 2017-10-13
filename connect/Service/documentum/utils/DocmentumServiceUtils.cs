using DocuSign.eSign.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace connect.Service.documentum.utils
{
     
    public class DocmentumServiceUtils
    {
        public static void ConfigureApiClient(string repo)
        {
            ApiClient apiClient = new ApiClient(ConfigurationManager.AppSettings["documentumUrl"].Replace("{REPO}", repo));
            string authHeader = " Basic " + CreateBasicBearToken(ConfigurationManager.AppSettings["dsUserName"],
                ConfigurationManager.AppSettings["dsUserPassword"]);
            // set client in global config so we don't need to pass it to each API object.
            DocuSign.eSign.Client.Configuration.Default.ApiClient = apiClient;

            if (DocuSign.eSign.Client.Configuration.Default.DefaultHeader.ContainsKey("X-DocuSign-Authentication"))
            {
                DocuSign.eSign.Client.Configuration.Default.DefaultHeader.Remove("X-DocuSign-Authentication");
            }
            if (DocuSign.eSign.Client.Configuration.Default.DefaultHeader.ContainsKey("Authorization"))
            {
                DocuSign.eSign.Client.Configuration.Default.DefaultHeader.Remove("Authorization");
            }
            DocuSign.eSign.Client.Configuration.Default.AddDefaultHeader("Authorization", authHeader);
            DocuSign.eSign.Client.Configuration.Default.AddDefaultHeader("Content-Type", "application/vnd.emc.documentum+json");
        }

        public static string CreateBasicBearToken(string userName = null, string password = null)
        {
            string documentumUserName = null;
            string documentumPassword = null;
            if (userName == null) userName = ConfigurationManager.AppSettings["documentumUserName"];
            if (password == null) password = ConfigurationManager.AppSettings["documentumPassword"];
            string baseOauth = userName + ":" + password;
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(baseOauth));
        }
    }
}