using Emc.Documentum.FS.DataModel.Core;
using Emc.Documentum.FS.DataModel.Core.Content;
using Emc.Documentum.FS.DataModel.Core.Context;
using Emc.Documentum.FS.DataModel.Core.Profiles;
using Emc.Documentum.FS.Runtime.Context;
using Emc.Documentum.FS.Services.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

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

        static DocumentumService()
        {
            documentumUrl = ConfigurationManager.AppSettings["documentumUrl"];
            documentumUserName = ConfigurationManager.AppSettings["documentumUserName"];
            documentumPassword = ConfigurationManager.AppSettings["documentumPassword"];

            // perform initialization here
            ContextFactory contextFactory = ContextFactory.Instance;
            serviceContext = contextFactory.NewContext();
            RepositoryIdentity repositoryIdentity =
                new RepositoryIdentity(repository, documentumUserName, documentumPassword, "");
            serviceContext.AddIdentity(repositoryIdentity);

            ServiceFactory serviceFactory = ServiceFactory.Instance;
            objectService = serviceFactory.GetRemoteService<IObjectService>(serviceContext, moduleName, "");
            querySvc = serviceFactory.GetRemoteService<IQueryService>(serviceContext, moduleName, "");
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