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
        public static void ConfigureApiClient(string domain)
        {
            ApiClient apiClient = new ApiClient(ConfigurationManager.AppSettings["documentumUrl"]);
            string authHeader = " Basic " + CreateBasicBearToken(ConfigurationManager.AppSettings["dsUserName"],
                ConfigurationManager.AppSettings["dsUserPassword"]);
            // set client in global config so we don't need to pass it to each API object.
            DocuSign.eSign.Client.Configuration.Default.ApiClient = apiClient;

            if (DocuSign.eSign.Client.Configuration.Default.DefaultHeader.ContainsKey("Authorization"))
            {
                DocuSign.eSign.Client.Configuration.Default.DefaultHeader.Remove("Authorization");
            }
            DocuSign.eSign.Client.Configuration.Default.AddDefaultHeader("Authorization", authHeader);
        }

        private static string CreateBasicBearToken(string userName, string password)
        {
            string baseOauth = ConfigurationManager.AppSettings["documentumUserName"] 
                + ":"
                + ConfigurationManager.AppSettings["documentumPassword"];
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(baseOauth));
        }
    }
}