﻿using System;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Xml;

namespace ResourceRequestService.Helpers
{
    public class SamlResponse
    {
        private static byte[] StringToByteArray(string st)
        {
            byte[] bytes = new byte[st.Length];
            for (int i = 0; i < st.Length; i++)
            {
                bytes[i] = (byte)st[i];
            }
            return bytes;
        }

        protected XmlDocument _xmlDoc;
        protected readonly X509Certificate2 _certificate;
        protected XmlNamespaceManager _xmlNameSpaceManager; //we need this one to run our XPath queries on the SAML XML

        public string Xml { get { return _xmlDoc.OuterXml; } }

        public SamlResponse()
        {

        }
        public SamlResponse(string certificateStr, string responseString) : this(StringToByteArray(certificateStr), responseString) { }

        public SamlResponse(byte[] certificateBytes, string responseString) : this(certificateBytes)
        {
            LoadXmlFromBase64(responseString);
        }

        public SamlResponse(string certificateStr) : this(StringToByteArray(certificateStr)) { }

        public SamlResponse(byte[] certificateBytes)
        {
            //RSAPKCS1SHA256SignatureDescription.Init (); //init the SHA256 crypto provider (for needed for .NET 4.0 and lower)
            _certificate = new X509Certificate2(certificateBytes);
        }

        public void LoadXml(string xml)
        {
            _xmlDoc = new XmlDocument();
            _xmlDoc.PreserveWhitespace = true;
            _xmlDoc.XmlResolver = null;
            _xmlDoc.LoadXml(xml);

            _xmlNameSpaceManager = GetNamespaceManager(); //lets construct a "manager" for XPath queries
        }

        public void LoadXmlFromBase64(string response)
        {
            UTF8Encoding enc = new UTF8Encoding();
            LoadXml(enc.GetString(Convert.FromBase64String(response)));
        }

        public bool IsValid()
        {
            XmlNodeList nodeList = _xmlDoc.SelectNodes("//ds:Signature", _xmlNameSpaceManager);

            SignedXml signedXml = new SignedXml(_xmlDoc);

            if (nodeList.Count == 0) return false;

            signedXml.LoadXml((XmlElement)nodeList[0]);
            return ValidateSignatureReference(signedXml) && signedXml.CheckSignature(_certificate, true) && !IsExpired();
        }

        //an XML signature can "cover" not the whole document, but only a part of it
        //.NET's built in "CheckSignature" does not cover this case, it will validate to true.
        //We should check the signature reference, so it "references" the id of the root document element! If not - it's a hack
        private bool ValidateSignatureReference(SignedXml signedXml)
        {
            if (signedXml.SignedInfo.References.Count != 1) //no ref at all
                return false;

            var reference = (Reference)signedXml.SignedInfo.References[0];
            var id = reference.Uri.Substring(1);

            var idElement = signedXml.GetIdElement(_xmlDoc, id);

            if (idElement == _xmlDoc.DocumentElement)
                return true;
            else //sometimes its not the "root" doc-element that is being signed, but the "assertion" element
            {
                var assertionNode = _xmlDoc.SelectSingleNode("/samlp:Response/saml:Assertion", _xmlNameSpaceManager) as XmlElement;
                if (assertionNode != idElement)
                    return false;
            }

            return true;
        }

        private bool IsExpired()
        {
            DateTime expirationDate = DateTime.MaxValue;
            XmlNode node = _xmlDoc.SelectSingleNode("/samlp:Response/saml:Assertion[1]/saml:Subject/saml:SubjectConfirmation/saml:SubjectConfirmationData", _xmlNameSpaceManager);
            if (node != null && node.Attributes["NotOnOrAfter"] != null)
            {
                DateTime.TryParse(node.Attributes["NotOnOrAfter"].Value, out expirationDate);
            }
            return DateTime.UtcNow > expirationDate.ToUniversalTime();
        }

        public string GetNameID()
        {
            XmlNode node = _xmlDoc.SelectSingleNode("/samlp:Response/saml:Assertion[1]/saml:Subject/saml:NameID", _xmlNameSpaceManager);
            return node.InnerText;
        }

        public string GetUpn()
        {
            return GetCustomAttribute("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/upn");
        }

        public string GetEmail()
        {
            return GetCustomAttribute("User.email") ??
                GetCustomAttribute("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress") //some providers (for example Azure AD) put last name into an attribute named "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"
                ??
                GetCustomAttribute("mail"); //some providers put last name into an attribute named "mail"
        }

        public string GetFirstName()
        {
            return GetCustomAttribute("first_name") ??
                GetCustomAttribute("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname") //some providers (for example Azure AD) put last name into an attribute named "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname"
                ??
                GetCustomAttribute("User.FirstName") ??
                GetCustomAttribute("givenName"); //some providers put last name into an attribute named "givenName"
        }

        public string GetLastName()
        {
            return GetCustomAttribute("last_name") ??
                GetCustomAttribute("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname") //some providers (for example Azure AD) put last name into an attribute named "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname"
                ??
                GetCustomAttribute("User.LastName") ??
                GetCustomAttribute("sn"); //some providers put last name into an attribute named "sn"
        }

        public string GetDepartment()
        {
            return GetCustomAttribute("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/department");
        }

        public string GetPhone()
        {
            return GetCustomAttribute("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/homephone") ??
                GetCustomAttribute("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/telephonenumber");
        }

        public string GetCompany()
        {
            return GetCustomAttribute("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/companyname") ??
                GetCustomAttribute("User.CompanyName");
        }

        public string GetCustomAttribute(string attr)
        {
            XmlNode node = _xmlDoc.SelectSingleNode("/samlp:Response/saml:Assertion[1]/saml:AttributeStatement/saml:Attribute[@Name='" + attr + "']/saml:AttributeValue", _xmlNameSpaceManager);
            return node?.InnerText;
        }

        //returns namespace manager, we need one b/c MS says so... Otherwise XPath doesnt work in an XML doc with namespaces
        //see https://stackoverflow.com/questions/7178111/why-is-xmlnamespacemanager-necessary
        private XmlNamespaceManager GetNamespaceManager()
        {
            XmlNamespaceManager manager = new XmlNamespaceManager(_xmlDoc.NameTable);
            manager.AddNamespace("ds", SignedXml.XmlDsigNamespaceUrl);
            manager.AddNamespace("saml", "urn:oasis:names:tc:SAML:2.0:assertion");
            manager.AddNamespace("samlp", "urn:oasis:names:tc:SAML:2.0:protocol");

            return manager;
        }
    }
}
