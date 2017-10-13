using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DocuSign.Connect;
using connect.Service.docusign;
using DocuSign.eSign.Model;
using connect.Service.docusign.utils;
using System.ComponentModel;
using System.IO;
using connect.Models.documentum;
using connect.Service.documentum;
using log4net;

namespace connect.Service.hangfire.tasks
{
    public static class DocumentumUploadTask
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(DocumentumUploadTask));

        //[DisplayName("Send order #{envelopeInfo.EnvelopeStatus.EnvelopeID} to warehouse")]
        /*public static void uploadDocuments(DocuSignEnvelopeInformation envelopeInfo)
        {
            Predicate<CustomField> accountFinder = (CustomField p) => { return p.Name == "AccountId"; };
            DocuSignService.GetDocument(ServiceUtil.buildEnvironment(envelopeInfo),
                envelopeInfo.EnvelopeStatus.EnvelopeID,
                envelopeInfo.EnvelopeStatus.DocumentStatuses.DocumentStatus.ID,
                DocumentOptions.Individual);
        }*/
        [DisplayName("Uploading document {3} for envelope {2}")]
        public static void uploadDocument(string domain, string account,
            string envelopeId, string documentId, DocumentOptions options)
        {
            MemoryStream docStream = DocuSignService.GetDocument(domain, account,
                envelopeId,
                documentId,
                options);



            byte[] buffer = ServiceUtil.ReadFully(docStream);
           

            //ContentPropertyResponse response = DocumentumService.CreateContentlessDocumentLinkToFolder("ECMTEST", "0b7e5f9f80458b40");
            var response = DocumentumService.uploadDocument("ECMTEST", "0b7e5f9f80458b40", buffer);
            Log.Debug("Properties created: ");
        }
    }
}   