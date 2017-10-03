using connect.Models.documentum;
using connect.Service.documentum.api;
using connect.Service.documentum.utils;
using DocuSign.eSign.Client;
using Emc.Documentum.FS.DataModel.Core;
using Emc.Documentum.FS.Runtime.Context;
using Emc.Documentum.FS.Services.Core;
using log4net;
using System;


namespace connect.Service.documentum
{
    public static class DocumentumService
    {
        /* The repository that you want to run the query on */
        private static String repository = "YOUR_REPOSITORY_NAME";

        /* The username to login to the repository */
        private static String documentumUserName;

        /* The password for the username */
        private static String documentumPassword;

        /* The address where the DFS services are located */
        private static string documentumUrl;

        /* The module name for the DFS core services */
        private static String moduleName = "core";
        private static IServiceContext serviceContext;
        private static IObjectService objectService;
        private static IQueryService querySvc;
        private static readonly ILog Log = LogManager.GetLogger(typeof(DocumentumService));

        static DocumentumService()
        {
            documentumUrl = System.Configuration.ConfigurationManager.AppSettings["documentumFCPort"];
            documentumUserName = System.Configuration.ConfigurationManager.AppSettings["documentumUserName"];
            documentumPassword = System.Configuration.ConfigurationManager.AppSettings["documentumPassword"];

            // perform initialization here
            /*ContextFactory contextFactory = ContextFactory.Instance;
            serviceContext = contextFactory.NewContext();
            RepositoryIdentity repositoryIdentity =
                new RepositoryIdentity(repository, documentumUserName, documentumPassword, "");
            serviceContext.AddIdentity(repositoryIdentity);

            ServiceFactory serviceFactory = ServiceFactory.Instance;
            objectService = serviceFactory.GetRemoteService<IObjectService>(serviceContext, moduleName, "");
            querySvc = serviceFactory.GetRemoteService<IQueryService>(serviceContext, moduleName, "");*/
           
        }

        public static ContentPropertyResponse CreateContentlessDocumentLinkToFolder(string repo, string folderId)
        {
            DocmentumServiceUtils.ConfigureApiClient(repo);
            ContentProperty contentProperty = new ContentProperty();
            contentProperty.properties = new PropertiesType();
            contentProperty.properties.r_object_type = "dwr_gen_doc";
            contentProperty.properties.object_name = "readme6";
            contentProperty.properties.author_creator = "Pedro Barroso";
            contentProperty.properties.author_date = "2017-09-26"; // new DateTime(2017, 9, 26);
            contentProperty.properties.topic_subject = "The subject";
            //contentProperty.properties.r_full_content_size = 100;
            //contentProperty.properties.format_name = "txt";
            IDocumentumApi documentumApi = new DocumentumApi();
            ContentPropertyResponse response = null;
            try
            {
                response = documentumApi.CreateContentlessDocument(repo, folderId, contentProperty);
            } 
            catch (ApiException ex)
            {
                Log.Error(ex);
            }
            return response;

        }
        public static DataObject uploadDocument(string repo, string folder)
        {
           
          
          // create a contentless document to link into folder  
          String objectName = "linkedDocument" + System.DateTime.Now.Ticks;
          String repositoryName = documentumUrl;  
          ObjectIdentity sampleObjId = new ObjectIdentity(repositoryName);  
          DataObject sampleDataObject = new DataObject(sampleObjId, "dm_document");  
          sampleDataObject.Properties.Set("object_name", objectName);  
          // add the folder to link to as a ReferenceRelationship  
          ObjectPath objectPath = new ObjectPath(folder);
          ObjectIdentity sampleFolderIdentity = new ObjectIdentity(objectPath, repo);  
          ReferenceRelationship sampleFolderRelationship = new ReferenceRelationship();  
          sampleFolderRelationship.Name = Relationship.RELATIONSHIP_FOLDER;  
          sampleFolderRelationship.Target = sampleFolderIdentity;  
          sampleFolderRelationship.TargetRole = Relationship.ROLE_PARENT;  
          sampleDataObject.Relationships.Add(sampleFolderRelationship);  
          // create a new document linked into parent folder  
          OperationOptions operationOptions = null;  
          DataPackage dataPackage = new DataPackage(sampleDataObject);
          objectService.Create(dataPackage, operationOptions);  
          return sampleDataObject; 
        }
        

    }
}