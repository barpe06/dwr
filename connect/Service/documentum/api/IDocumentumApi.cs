using System;
namespace connect.Service.documentum.api
{
    interface IDocumentumApi
    {
        connect.Models.documentum.ContentPropertyResponse CreateContentlessDocument(string repo, string folderId, connect.Models.documentum.ContentProperty contentProperty);
        DocuSign.eSign.Client.ApiResponse<connect.Models.documentum.ContentPropertyResponse> CreateContentlessDocumentWithHttpInfo(string repo, string folderId, connect.Models.documentum.ContentProperty contentProperty = null);
    }
}
