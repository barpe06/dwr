using connect.Models.documentum;
using DocuSign.eSign.Client;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace connect.Service.documentum.api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    
    public partial class DocumentumApi : IDocumentumApi
    {
        private DocuSign.eSign.Client.ExceptionFactory _exceptionFactory = (name, response) => null;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentumApi"/> class.
        /// </summary>
        /// <returns></returns>
        public DocumentumApi(String basePath)
        {
            this.Configuration = new Configuration(new ApiClient(basePath));

            ExceptionFactory = DocuSign.eSign.Client.Configuration.DefaultExceptionFactory;

            // ensure API client has configuration ready
            if (Configuration.ApiClient.Configuration == null)
            {
                this.Configuration.ApiClient.Configuration = this.Configuration;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentumApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public DocumentumApi(Configuration configuration = null)
        {
            if (configuration == null) // use the default one in Configuration
                this.Configuration = Configuration.Default;
            else
                this.Configuration = configuration;

            ExceptionFactory = DocuSign.eSign.Client.Configuration.DefaultExceptionFactory;

            // ensure API client has configuration ready
            if (Configuration.ApiClient.Configuration == null)
            {
                this.Configuration.ApiClient.Configuration = this.Configuration;
            }
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.Configuration.ApiClient.RestClient.BaseUrl.ToString();
        }

        public Configuration Configuration { get; set; }

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public DocuSign.eSign.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        public ApiResponse<ContentPropertyResponse> CreateContentlessDocumentWithHttpInfo(string repo, string folderId, ContentProperty contentProperty = null)
        {
            // verify the required parameter 'accountId' is set
            if (repo == null)
                throw new ApiException(400, "Missing required envelope custom field parameter 'documentum repository' when calling DocumentumService->uploadDocument");
            // verify the required parameter 'documentId' is set
            if (folderId == null)
                throw new ApiException(400, "Missing required envelope custom field parameter 'folder' when calling DocumentumService->uploadDocument");

            var localVarPath = "/folders/{folderId}/documents".Replace("{folderId}",folderId);
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.Default.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                 "application/vnd.emc.documentum+json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);
           // localVarHttpContentType = "application/vnd.emc.documentum+json";

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/vnd.emc.documentum+json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                if (localVarHttpContentType.Contains("Accept"))
                {
                    localVarHeaderParams.Remove("Accept");
                }
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (localVarHttpContentType != null)
                /*if (localVarHttpContentType.Contains("Content-Type"))
                {
                    localVarHeaderParams.Remove("Content-Type");
                }
                localVarHeaderParams.Add("Content-Type", localVarHttpContentType);*/
            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            //localVarPathParams.Add("format", "json");

            if (contentProperty != null && contentProperty.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(contentProperty); // http body (model) parameter
            }
            else
            {
                localVarPostBody = contentProperty; // byte array
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("CreateContentless", localVarResponse);
                if (exception != null) throw exception;
            }
               

            // DocuSign: Handle for PDF return types
            if (localVarResponse.ContentType != null && !localVarResponse.ContentType.ToLower().Contains("json"))
            {
                return new ApiResponse<ContentPropertyResponse>(localVarStatusCode, localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()), (ContentPropertyResponse)Configuration.ApiClient.Deserialize(localVarResponse.RawBytes, typeof(ContentPropertyResponse)));
            }
            else
            {
                return new ApiResponse<ContentPropertyResponse>(localVarStatusCode, localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()), (ContentPropertyResponse)Configuration.ApiClient.Deserialize(localVarResponse, typeof(ContentPropertyResponse)));
            }



        }

        /// <returns>ContentPropertyResponse</returns>
        public ContentPropertyResponse  CreateContentlessDocument(string repo, string folderId, ContentProperty contentProperty){
            ApiResponse<ContentPropertyResponse> localVarResponse = CreateContentlessDocumentWithHttpInfo(repo, folderId, contentProperty);
            return localVarResponse.Data;
        }
    }
}