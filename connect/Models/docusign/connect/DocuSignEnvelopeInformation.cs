﻿/* 
 Licensed under the Apache License, Version 2.0
    
 http://www.apache.org/licenses/LICENSE-2.0
 */
using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace DocuSign.Connect
{
    [XmlRoot(ElementName = "DeclineReason", Namespace = "http://www.docusign.net/API/3.0")]
    public class DeclineReason
    {
        [XmlAttribute(AttributeName = "nil", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string Nil { get; set; }
    }

    [XmlRoot(ElementName = "TabStatus", Namespace = "http://www.docusign.net/API/3.0")]
    public class TabStatus
    {
        [XmlElement(ElementName = "TabType", Namespace = "http://www.docusign.net/API/3.0")]
        public string TabType { get; set; }
        [XmlElement(ElementName = "Status", Namespace = "http://www.docusign.net/API/3.0")]
        public string Status { get; set; }
        [XmlElement(ElementName = "XPosition", Namespace = "http://www.docusign.net/API/3.0")]
        public string XPosition { get; set; }
        [XmlElement(ElementName = "YPosition", Namespace = "http://www.docusign.net/API/3.0")]
        public string YPosition { get; set; }
        [XmlElement(ElementName = "TabLabel", Namespace = "http://www.docusign.net/API/3.0")]
        public string TabLabel { get; set; }
        [XmlElement(ElementName = "TabName", Namespace = "http://www.docusign.net/API/3.0")]
        public string TabName { get; set; }
        [XmlElement(ElementName = "TabValue", Namespace = "http://www.docusign.net/API/3.0")]
        public string TabValue { get; set; }
        [XmlElement(ElementName = "DocumentID", Namespace = "http://www.docusign.net/API/3.0")]
        public string DocumentID { get; set; }
        [XmlElement(ElementName = "PageNumber", Namespace = "http://www.docusign.net/API/3.0")]
        public string PageNumber { get; set; }
        [XmlElement(ElementName = "OriginalValue", Namespace = "http://www.docusign.net/API/3.0")]
        public string OriginalValue { get; set; }
        [XmlElement(ElementName = "CustomTabType", Namespace = "http://www.docusign.net/API/3.0")]
        public string CustomTabType { get; set; }
        [XmlElement(ElementName = "ValidationPattern", Namespace = "http://www.docusign.net/API/3.0")]
        public string ValidationPattern { get; set; }
    }

    [XmlRoot(ElementName = "TabStatuses", Namespace = "http://www.docusign.net/API/3.0")]
    public class TabStatuses
    {
        [XmlElement(ElementName = "TabStatus", Namespace = "http://www.docusign.net/API/3.0")]
        public List<TabStatus> TabStatus { get; set; }
    }

    [XmlRoot(ElementName = "RecipientStatus", Namespace = "http://www.docusign.net/API/3.0")]
    public class RecipientStatus
    {
        [XmlElement(ElementName = "Type", Namespace = "http://www.docusign.net/API/3.0")]
        public string Type { get; set; }
        [XmlElement(ElementName = "Email", Namespace = "http://www.docusign.net/API/3.0")]
        public string Email { get; set; }
        [XmlElement(ElementName = "UserName", Namespace = "http://www.docusign.net/API/3.0")]
        public string UserName { get; set; }
        [XmlElement(ElementName = "RoutingOrder", Namespace = "http://www.docusign.net/API/3.0")]
        public string RoutingOrder { get; set; }
        [XmlElement(ElementName = "Sent", Namespace = "http://www.docusign.net/API/3.0")]
        public string Sent { get; set; }
        [XmlElement(ElementName = "Delivered", Namespace = "http://www.docusign.net/API/3.0")]
        public string Delivered { get; set; }
        [XmlElement(ElementName = "DeclineReason", Namespace = "http://www.docusign.net/API/3.0")]
        public DeclineReason DeclineReason { get; set; }
        [XmlElement(ElementName = "Status", Namespace = "http://www.docusign.net/API/3.0")]
        public string Status { get; set; }
        [XmlElement(ElementName = "RecipientIPAddress", Namespace = "http://www.docusign.net/API/3.0")]
        public string RecipientIPAddress { get; set; }
        [XmlElement(ElementName = "CustomFields", Namespace = "http://www.docusign.net/API/3.0")]
        public string CustomFields { get; set; }
        [XmlElement(ElementName = "TabStatuses", Namespace = "http://www.docusign.net/API/3.0")]
        public TabStatuses TabStatuses { get; set; }
        [XmlElement(ElementName = "AccountStatus", Namespace = "http://www.docusign.net/API/3.0")]
        public string AccountStatus { get; set; }
        [XmlElement(ElementName = "RecipientId", Namespace = "http://www.docusign.net/API/3.0")]
        public string RecipientId { get; set; }
    }

    [XmlRoot(ElementName = "RecipientStatuses", Namespace = "http://www.docusign.net/API/3.0")]
    public class RecipientStatuses
    {
        [XmlElement(ElementName = "RecipientStatus", Namespace = "http://www.docusign.net/API/3.0")]
        public RecipientStatus RecipientStatus { get; set; }
    }

    [XmlRoot(ElementName = "CustomField", Namespace = "http://www.docusign.net/API/3.0")]
    public class CustomField
    {
        [XmlElement(ElementName = "Name", Namespace = "http://www.docusign.net/API/3.0")]
        public string Name { get; set; }
        [XmlElement(ElementName = "Show", Namespace = "http://www.docusign.net/API/3.0")]
        public string Show { get; set; }
        [XmlElement(ElementName = "Required", Namespace = "http://www.docusign.net/API/3.0")]
        public string Required { get; set; }
        [XmlElement(ElementName = "Value", Namespace = "http://www.docusign.net/API/3.0")]
        public string Value { get; set; }
        [XmlElement(ElementName = "CustomFieldType", Namespace = "http://www.docusign.net/API/3.0")]
        public string CustomFieldType { get; set; }
    }

    [XmlRoot(ElementName = "CustomFields", Namespace = "http://www.docusign.net/API/3.0")]
    public class CustomFields
    {
        [XmlElement(ElementName = "CustomField", Namespace = "http://www.docusign.net/API/3.0")]
        public List<CustomField> CustomField { get; set; }
    }

    [XmlRoot(ElementName = "DocumentStatus", Namespace = "http://www.docusign.net/API/3.0")]
    public class DocumentStatus
    {
        [XmlElement(ElementName = "ID", Namespace = "http://www.docusign.net/API/3.0")]
        public string ID { get; set; }
        [XmlElement(ElementName = "Name", Namespace = "http://www.docusign.net/API/3.0")]
        public string Name { get; set; }
        [XmlElement(ElementName = "TemplateName", Namespace = "http://www.docusign.net/API/3.0")]
        public string TemplateName { get; set; }
        [XmlElement(ElementName = "Sequence", Namespace = "http://www.docusign.net/API/3.0")]
        public string Sequence { get; set; }
    }

    [XmlRoot(ElementName = "DocumentStatuses", Namespace = "http://www.docusign.net/API/3.0")]
    public class DocumentStatuses
    {
        [XmlElement(ElementName = "DocumentStatus", Namespace = "http://www.docusign.net/API/3.0")]
        public DocumentStatus DocumentStatus { get; set; }
    }

    [XmlRoot(ElementName = "EnvelopeStatus", Namespace = "http://www.docusign.net/API/3.0")]
    public class EnvelopeStatus
    {
        [XmlElement(ElementName = "RecipientStatuses", Namespace = "http://www.docusign.net/API/3.0")]
        public RecipientStatuses RecipientStatuses { get; set; }
        [XmlElement(ElementName = "TimeGenerated", Namespace = "http://www.docusign.net/API/3.0")]
        public string TimeGenerated { get; set; }
        [XmlElement(ElementName = "EnvelopeID", Namespace = "http://www.docusign.net/API/3.0")]
        public string EnvelopeID { get; set; }
        [XmlElement(ElementName = "Subject", Namespace = "http://www.docusign.net/API/3.0")]
        public string Subject { get; set; }
        [XmlElement(ElementName = "UserName", Namespace = "http://www.docusign.net/API/3.0")]
        public string UserName { get; set; }
        [XmlElement(ElementName = "Email", Namespace = "http://www.docusign.net/API/3.0")]
        public string Email { get; set; }
        [XmlElement(ElementName = "Status", Namespace = "http://www.docusign.net/API/3.0")]
        public string Status { get; set; }
        [XmlElement(ElementName = "Created", Namespace = "http://www.docusign.net/API/3.0")]
        public string Created { get; set; }
        [XmlElement(ElementName = "Sent", Namespace = "http://www.docusign.net/API/3.0")]
        public string Sent { get; set; }
        [XmlElement(ElementName = "Delivered", Namespace = "http://www.docusign.net/API/3.0")]
        public string Delivered { get; set; }
        [XmlElement(ElementName = "ACStatus", Namespace = "http://www.docusign.net/API/3.0")]
        public string ACStatus { get; set; }
        [XmlElement(ElementName = "ACStatusDate", Namespace = "http://www.docusign.net/API/3.0")]
        public string ACStatusDate { get; set; }
        [XmlElement(ElementName = "ACHolder", Namespace = "http://www.docusign.net/API/3.0")]
        public string ACHolder { get; set; }
        [XmlElement(ElementName = "ACHolderEmail", Namespace = "http://www.docusign.net/API/3.0")]
        public string ACHolderEmail { get; set; }
        [XmlElement(ElementName = "ACHolderLocation", Namespace = "http://www.docusign.net/API/3.0")]
        public string ACHolderLocation { get; set; }
        [XmlElement(ElementName = "SigningLocation", Namespace = "http://www.docusign.net/API/3.0")]
        public string SigningLocation { get; set; }
        [XmlElement(ElementName = "SenderIPAddress", Namespace = "http://www.docusign.net/API/3.0")]
        public string SenderIPAddress { get; set; }
        [XmlElement(ElementName = "EnvelopePDFHash", Namespace = "http://www.docusign.net/API/3.0")]
        public string EnvelopePDFHash { get; set; }
        [XmlElement(ElementName = "CustomFields", Namespace = "http://www.docusign.net/API/3.0")]
        public CustomFields CustomFields { get; set; }
        [XmlElement(ElementName = "AutoNavigation", Namespace = "http://www.docusign.net/API/3.0")]
        public string AutoNavigation { get; set; }
        [XmlElement(ElementName = "EnvelopeIdStamping", Namespace = "http://www.docusign.net/API/3.0")]
        public string EnvelopeIdStamping { get; set; }
        [XmlElement(ElementName = "AuthoritativeCopy", Namespace = "http://www.docusign.net/API/3.0")]
        public string AuthoritativeCopy { get; set; }
        [XmlElement(ElementName = "DocumentStatuses", Namespace = "http://www.docusign.net/API/3.0")]
        public DocumentStatuses DocumentStatuses { get; set; }
    }

    [XmlRoot(ElementName = "DocuSignEnvelopeInformation", Namespace = "http://www.docusign.net/API/3.0")]
    public class DocuSignEnvelopeInformation
    {
        [XmlElement(ElementName = "EnvelopeStatus", Namespace = "http://www.docusign.net/API/3.0")]
        public EnvelopeStatus EnvelopeStatus { get; set; }
        [XmlElement(ElementName = "TimeZone", Namespace = "http://www.docusign.net/API/3.0")]
        public string TimeZone { get; set; }
        [XmlElement(ElementName = "TimeZoneOffset", Namespace = "http://www.docusign.net/API/3.0")]
        public string TimeZoneOffset { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
        [XmlAttribute(AttributeName = "xsd", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsd { get; set; }
        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsi { get; set; }
    }

}
