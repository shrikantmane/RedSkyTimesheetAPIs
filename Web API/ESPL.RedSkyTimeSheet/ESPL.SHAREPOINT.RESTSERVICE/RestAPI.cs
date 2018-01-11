using ESPL.ERRORLOGGER;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace ESPL.SHAREPOINT.RESTSERVICE
{
    public static class RestAPI
    {
        /// <summary>
        /// Add items to list
        /// </summary>
        /// <param name="siteUrl"></param>
        /// <param name="errorLogPath"></param>
        /// <param name="accessToken"></param>
        /// <param name="ListUrl"></param>
        /// <param name="ListItemUrl"></param>
        /// <param name="itemPostBody"></param>
        /// <param name="xmlnspm"></param>
        /// <param name="formDigestNode"></param>
        /// <returns></returns>
        public static string AddListItems(string siteUrl, string errorLogPath, string accessToken, string listUrl, string listItemUrl, string itemPostBody, string userID)
        {
            try
            {
                XmlNamespaceManager xmlnspm = AddXmlNameSpaces();
                var formDigestNode = GetFormDigest(siteUrl, accessToken, xmlnspm);

                //itemPostBody = itemPostBody.Remove(itemPostBody.LastIndexOf('}'));
                //itemPostBody = string.Concat(itemPostBody, ",'CreatedById':", userID, ",'ModifiedById':", userID, "}");
                string FormDigest = formDigestNode.InnerXml;
                string EntityTypeName = GetEntityTypeName(siteUrl, listUrl, xmlnspm);
                itemPostBody = itemPostBody.Replace("{0}", EntityTypeName);
                Byte[] itemPostData = System.Text.Encoding.ASCII.GetBytes(itemPostBody);
                HttpWebRequest ItemRequest;
                ItemRequest = (HttpWebRequest)HttpWebRequest.Create(string.Concat(siteUrl, listItemUrl));
                ItemRequest.Method = "POST";
                ItemRequest.ContentLength = itemPostBody.Length;
                ItemRequest.ContentType = "application/json;odata=verbose";
                ItemRequest.Accept = "application/json;odata=verbose";
                ItemRequest.Headers.Add("Authorization", "Bearer " + accessToken);
                ItemRequest.Credentials = System.Net.CredentialCache.DefaultCredentials;
                //ItemRequest.Credentials = new NetworkCredential("pranali.tupe","eternus@123","Eternus");
                ItemRequest.Headers.Add("X-RequestDigest", FormDigest);
                using (Stream itemRequestStream = ItemRequest.GetRequestStream())
                {
                    itemRequestStream.Write(itemPostData, 0, itemPostData.Length);
                    //itemRequestStream.Close();
                }
                HttpWebResponse itemResponse = (HttpWebResponse)ItemRequest.GetResponse();
                return null;
            }
            catch (Exception ex)
            {
                string guid = WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format("An error occurred while reading data. GUID: {0}", guid));
            }
        }

        public static string UpdateListItems(string siteUrl, string errorLogPath, string accessToken, string listUrl, string listItemUrl, string itemPostBody, string id, string userID)
        {
            try
            {
                XmlNamespaceManager xmlnspm = AddXmlNameSpaces();
                var formDigestNode = GetFormDigest(siteUrl, accessToken, xmlnspm);
                //itemPostBody = itemPostBody.Remove(itemPostBody.LastIndexOf('}'));
                //itemPostBody = string.Concat(itemPostBody, ",'ModifiedById':", userID, "}");
                string FormDigest = formDigestNode.InnerXml;
                string EntityTypeName = GetEntityTypeName(siteUrl, listUrl, xmlnspm);

                itemPostBody = itemPostBody.Replace("{0}", EntityTypeName);
                Byte[] itemPostData = System.Text.Encoding.ASCII.GetBytes(itemPostBody);

                HttpWebRequest ItemRequest =
                        (HttpWebRequest)HttpWebRequest.Create(string.Concat(siteUrl, listItemUrl, "(", id, ")"));
                ItemRequest.Method = "POST";
                ItemRequest.ContentLength = itemPostBody.Length;
                ItemRequest.Headers.Add("X-HTTP-Method", "MERGE");
                ItemRequest.Headers.Add("IF-MATCH", "*");
                ItemRequest.ContentType = "application/json;odata=verbose";
                ItemRequest.Accept = "application/json;odata=verbose";
                ItemRequest.Headers.Add("Authorization", "Bearer " + accessToken);

                ItemRequest.Credentials = System.Net.CredentialCache.DefaultCredentials;

                //ItemRequest.Credentials = new NetworkCredential("amruta.shinde", "espl@123", "Eternusdev");

                ItemRequest.Headers.Add("X-RequestDigest", FormDigest);
                using (Stream itemRequestStream = ItemRequest.GetRequestStream())
                {
                    itemRequestStream.Write(itemPostData, 0, itemPostData.Length);
                    //itemRequestStream.Close();
                }
                HttpWebResponse itemResponse = (HttpWebResponse)ItemRequest.GetResponse();
                return null;
            }
            catch (WebException ex)
            {
                string guid = WebException(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw new Exception(string.Format("An error occurred while reading data. GUID: {0}", guid));
            }
            catch (Exception ex)
            {
                string guid = WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format("An error occurred while reading data. GUID: {0}", guid));
            }
        }

        public static JArray GetDataFromCAMLQueryPOST(string RestUrl, string itempostBody, string siteUrl, string errorLogPath, string accessToken)
        {
            try
            {
                XmlNamespaceManager xmlnspm = AddXmlNameSpaces();
                var formDigestNode = GetFormDigest(siteUrl, accessToken, xmlnspm);
                string response = string.Empty;
                StreamReader st = new StreamReader(GetListItemsUsingPost(siteUrl, errorLogPath, accessToken, RestUrl, itempostBody, xmlnspm, formDigestNode));

                response = st.ReadToEnd();

                JObject jobj = JObject.Parse(response);
                return (JArray)jobj["d"]["results"];
            }
            catch (Exception ex)
            {
                string guid = WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format("An error occurred while reading data. GUID: {0}", guid));
            }
        }

        public static Stream GetListItemsUsingPost(string siteUrl, string errorLogPath, string accessToken, string RestUrl, string itemPostBody, XmlNamespaceManager xmlnspm, XmlNode formDigestNode)
        {
            try
            {
                string FormDigest = formDigestNode.InnerXml;
                Byte[] itemPostData = System.Text.Encoding.ASCII.GetBytes(itemPostBody);

                HttpWebRequest ItemRequest = (HttpWebRequest)HttpWebRequest.Create(RestUrl);
                ItemRequest.Method = "POST";
                ItemRequest.ContentLength = itemPostBody.Length;

                ItemRequest.ContentType = "application/json;odata=verbose";
                ItemRequest.Accept = "application/json;odata=verbose";
                ItemRequest.Headers.Add("Authorization", "Bearer " + accessToken);
                ItemRequest.Credentials = System.Net.CredentialCache.DefaultCredentials;

                ItemRequest.Headers.Add("X-RequestDigest", FormDigest);
                using (Stream itemRequestStream = ItemRequest.GetRequestStream())
                {
                    itemRequestStream.Write(itemPostData, 0, itemPostData.Length);
                    //itemRequestStream.Close();
                }
                HttpWebResponse itemResponse = (HttpWebResponse)ItemRequest.GetResponse();

                return itemResponse.GetResponseStream();

            }
            catch (WebException ex)
            {
                string guid = WebException(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw new Exception(string.Format("An error occurred while reading data. GUID: {0}", guid));
            }
            catch (Exception ex)
            {
                string guid = WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format("An error occurred while reading data. GUID: {0}", guid));
            }

        }

        /// <summary>
        /// Overloaded Method to return stream from HttpWebRequest endPointRequest by passing default credentials
        /// </summary>
        /// <param name="restURL"></param>
        /// <param name="credentials"></param>
        /// <returns></returns>
        public static JObject GetResponseFromEndPointRequest(string restURL, ICredentials credentials)
        {
            JObject jobj;
            try
            {
                HttpWebRequest endpointRequest = (HttpWebRequest)HttpWebRequest.Create(restURL);
                endpointRequest.Method = "GET";
                endpointRequest.Accept = "application/json;odata=verbose";
                endpointRequest.ContentType = "application/json; charset=utf-8";
                endpointRequest.Credentials = credentials;
                HttpWebResponse itemResponse = (HttpWebResponse)endpointRequest.GetResponse();

                using (StreamReader responseReader = new StreamReader(itemResponse.GetResponseStream()))
                {
                    string response = responseReader.ReadToEnd();
                    jobj = JObject.Parse(response);
                }

                return jobj;
            }
            catch (WebException ex)
            {
                string guid = WebException(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw new Exception(string.Format("An error occurred while reading data. GUID: {0}", guid));
            }
            catch (Exception ex)
            {
                string guid = WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format("An error occurred while reading data. GUID: {0}", guid));
            }
        }

        public static string WebException(WebException ex, string methodName)
        {
            string guid = Convert.ToString(Guid.NewGuid());
            if (ex.Status == WebExceptionStatus.ProtocolError)
            {
                var resp = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                dynamic obj = JsonConvert.DeserializeObject(resp);
                string errorMessage = Convert.ToString(obj.error.message.value);
                string stackTrace = Convert.ToString(obj.error.innererror.stacktrace);
                string innerException = Convert.ToString(ex.Message);
                ErrorLogger errorLogger = new ErrorLogger();
                errorLogger.Log(errorMessage, stackTrace, "", methodName, "Error in SharePoint REST Service", innerException, guid);
            }
            return guid;
        }

        public static string WriteException(Exception ex, string methodName, string className)
        {
            ErrorLogger errorLogger = new ErrorLogger();
            string guid = Convert.ToString(Guid.NewGuid());
            errorLogger.Log(ex.Message, ex.StackTrace, "", methodName, className, Convert.ToString(ex.InnerException), guid);
            return guid;
        }

        /// <summary>
        /// Overloaded Method to return stream from HttpWebRequest endPointRequest by passing user-name and password in network credentials 
        /// </summary>
        /// <param name="restURL"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static JObject GetResponseFromEndPointRequest(string restURL, string userName, string password)
        {
            JObject jobj;
            try
            {
                HttpWebRequest endpointRequest = (HttpWebRequest)HttpWebRequest.Create(restURL);
                endpointRequest.Method = "GET";
                endpointRequest.Accept = "application/json;odata=verbose";
                endpointRequest.ContentType = "application/json; charset=utf-8";
                endpointRequest.Credentials = new NetworkCredential(userName, password);
                HttpWebResponse itemResponse = (HttpWebResponse)endpointRequest.GetResponse();
                using (StreamReader responseReader = new StreamReader(itemResponse.GetResponseStream()))
                {
                    string response = responseReader.ReadToEnd();
                    jobj = JObject.Parse(response);
                }
                return jobj;
            }
            catch (WebException ex)
            {
                string guid = WebException(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw new Exception(string.Format("An error occurred while reading data. GUID: {0}", guid));
            }
            catch (Exception ex)
            {
                string guid = WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format("An error occurred while reading data. GUID: {0}", guid));
            }
        }

        /// <summary>
        /// Overloaded Method to return stream from HttpWebRequest endPointRequest by passing access token in headers
        /// </summary>
        /// <param name="restURL"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static JObject GetResponseFromEndPointRequest(string restURL, string accessToken)
        {
            JObject jobj;
            try
            {
                HttpWebRequest endpointRequest = (HttpWebRequest)HttpWebRequest.Create(restURL);
                endpointRequest.Method = "GET";
                endpointRequest.Accept = "application/json;odata=verbose";
                endpointRequest.ContentType = "application/json; charset=utf-8";
                endpointRequest.Headers.Add("Authorization", "Bearer " + accessToken);
                HttpWebResponse itemResponse = (HttpWebResponse)endpointRequest.GetResponse();
                using (StreamReader responseReader = new StreamReader(itemResponse.GetResponseStream()))
                {
                    string response = responseReader.ReadToEnd();
                    jobj = JObject.Parse(response);
                }
                return jobj;
            }
            catch (WebException ex)
            {
                string guid = WebException(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw new Exception(string.Format("An error occurred while reading data. GUID: {0}", guid));
            }
            catch (Exception ex)
            {
                string guid = WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format("An error occurred while reading data. GUID: {0}", guid));
            }
        }

        /// <summary>
        /// Generate Unique ID's
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static string generateUniqueID(string Value)
        {
            return Value + System.DateTime.Now.Ticks.ToString().Replace(".", "").Replace(":", "").Replace("/", "").Replace("PM", "").Replace(" ", "").Remove(1, 8);
        }

        /// <summary>
        /// Get Form Digest value
        /// </summary>
        /// <param name="siteUrl"></param>
        /// <param name="accessToken"></param>
        /// <param name="xmlnspm"></param>
        /// <returns></returns>
        public static XmlNode GetFormDigest(string siteUrl, string accessToken, XmlNamespaceManager xmlnspm)
        {
            try
            {
                var formDigestXML = new XmlDocument();
                HttpWebRequest contextinfoRequest =
                    (HttpWebRequest)HttpWebRequest.Create(siteUrl + "/_api/contextinfo");
                contextinfoRequest.Method = "POST";
                contextinfoRequest.ContentType = "application/json; charset=utf-8";
                contextinfoRequest.ContentLength = 0;
                contextinfoRequest.Headers.Set(HttpRequestHeader.AcceptLanguage, "en-US");
                contextinfoRequest.Headers.Add("Authorization", "Bearer " + accessToken);
                CredentialCache myCache = new CredentialCache();

                contextinfoRequest.Credentials = System.Net.CredentialCache.DefaultCredentials;
                HttpWebResponse contextinfoResponse = (HttpWebResponse)contextinfoRequest.GetResponse();

                using (StreamReader contextinfoReader = new StreamReader(contextinfoResponse.GetResponseStream(), System.Text.Encoding.UTF8))
                {
                    formDigestXML.LoadXml(contextinfoReader.ReadToEnd());
                }

                var formDigestNode = formDigestXML.SelectSingleNode("//d:FormDigestValue", xmlnspm);
                return formDigestNode;
            }
            catch (WebException ex)
            {
                string guid = WebException(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw new Exception(string.Format("An error occurred while reading data. GUID: {0}", guid));
            }
            catch (Exception ex)
            {
                string guid = WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format("An error occurred while reading data. GUID: {0}", guid));
            }
        }

        /// <summary>
        /// Upload Files to Profile Bank
        /// </summary>
        /// <param name="UploadedFiles"></param>
        /// <param name="siteUrl"></param>
        /// <param name="errorLogPath"></param>
        /// <param name="accessToken"></param>
        /// <param name="DocumentLibUrl"></param>
        /// <param name="DocumentLibListUrl"></param>
        /// <param name="FolderName"></param>
        /// <param name="Overwrite"></param>
        /// <param name="itemPostBody"></param>
        /// <param name="xmlnspm"></param>
        /// <param name="formDigestNode"></param>
        /// <returns></returns>
        public static string UploadFiles(HttpFileCollection uploadedFiles, string siteUrl, string errorLogPath, string accessToken, string documentLibUrl, string documentLibListUrl, string folderName, bool overwrite, string itemPostBody, XmlNamespaceManager xmlnspm, XmlNode formDigestNode, out string profileDocName,string userID)
        {
            string ProfilePath = string.Empty;
            try
            {
                string formDigest = formDigestNode.InnerXml;
                //string entityTypeName = GetEntityTypeName(siteUrl, documentLibListUrl, xmlnspm);
                profileDocName = string.Empty;
                if (uploadedFiles.Count > 0)
                {
                    string MonthFolder = Convert.ToString(DateTime.Now.ToString("MMMM"));
                    string Year_MonthFolder = Convert.ToString(DateTime.Now.Year) + "_" + MonthFolder;
                    CreateFolder(siteUrl, errorLogPath, accessToken, documentLibUrl, "", Year_MonthFolder, false, xmlnspm, formDigestNode);
                    //CommonEntities.CreateFolder(siteUrl, errorLogPath, accessToken, documentLibUrl, YearFolder, MonthFolder, false, xmlnspm, formDigestNode);
                    string NewFileWithExtention = string.Empty;
                    int Counter = 0;
                    foreach (string file in uploadedFiles)
                    {
                        var postedFile = uploadedFiles[Counter];
                        var FileName = postedFile.FileName;
                        var FileExtention = Path.GetExtension(FileName);
                        byte[] fileData = null;
                        using (var binaryReader = new BinaryReader(postedFile.InputStream))
                        {
                            fileData = binaryReader.ReadBytes(postedFile.ContentLength);
                        }
                        string NewFileName = Convert.ToString(Guid.NewGuid());
                        NewFileWithExtention = NewFileName + FileExtention;
                        HttpWebRequest endpointRequest = (HttpWebRequest)HttpWebRequest.Create(siteUrl + "/_api/web/GetFolderByServerRelativeUrl('" + documentLibUrl + "/" + Year_MonthFolder + "')/Files/add(url='" + NewFileWithExtention + "',overwrite=" + Convert.ToString(overwrite).ToLower() + ")");
                        endpointRequest.Method = "POST";
                        endpointRequest.Headers.Add("binaryStringRequestBody", "true");
                        endpointRequest.Headers.Add("Authorization", "Bearer " + accessToken);
                        endpointRequest.Headers.Add("X-RequestDigest", formDigest);
                        endpointRequest.Credentials = System.Net.CredentialCache.DefaultCredentials;
                        endpointRequest.GetRequestStream().Write(fileData, 0, fileData.Length);

                        try
                        {
                            HttpWebResponse endpointresponse = (HttpWebResponse)endpointRequest.GetResponse();

                            UpdateMetadata(siteUrl, errorLogPath, accessToken, documentLibUrl, Year_MonthFolder, FileName, NewFileWithExtention, itemPostBody, documentLibListUrl, xmlnspm, formDigestNode,userID);

                        }
                        catch (WebException ex)
                        {
                            HttpWebResponse errorResponse = ex.Response as HttpWebResponse;

                            if (errorResponse.StatusCode == HttpStatusCode.NotFound)
                            {

                            }

                        }
                        catch (Exception ex)
                        {
                            string guid = WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);

                            throw new Exception(string.Format("An error occurred while reading data. GUID: {0}", guid));
                        }
                        Counter++;
                    }
                    if (Counter > 0)
                    {
                        ProfilePath = Year_MonthFolder;
                        profileDocName = NewFileWithExtention;
                    }
                }
            }
            catch (Exception ex)
            {
                string guid = WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format("An error occurred while reading data. GUID: {0}", guid));
            }
            return ProfilePath;

        }

        /// <summary>
        /// Create Folders and SubFolders in Document Library
        /// </summary>
        /// <param name="siteUrl"></param>
        /// <param name="errorLogPath"></param>
        /// <param name="accessToken"></param>
        /// <param name="listUrl"></param>
        /// <param name="rootFolderName"></param>
        /// <param name="SubFolderName"></param>
        /// <param name="Overwrite"></param>
        /// <returns></returns>
        public static bool CreateFolder(string siteUrl, string errorLogPath, string accessToken, string listUrl, string rootFolderName, string subFolderName, bool overwrite, XmlNamespaceManager xmlnspm, XmlNode formDigestNode)
        {
            bool isFileUploaded = false;
            try
            {
                string formDigest = formDigestNode.InnerXml;
                //string entityTypeName = GetEntityTypeName(siteUrl, listUrl, xmlnspm);

                HttpWebRequest endpointRequest;
                if (!string.IsNullOrEmpty(rootFolderName))
                    endpointRequest = (HttpWebRequest)HttpWebRequest.Create(siteUrl + "/_api/web/GetFolderByServerRelativeUrl('" + listUrl + "/" + rootFolderName + "')" + "/folders/add(url=\'" + subFolderName + "\')");
                else
                    endpointRequest = (HttpWebRequest)HttpWebRequest.Create(siteUrl + "/_api/web/Lists/GetByTitle('" + listUrl + "')" + "/rootfolder/folders/add(url=\'" + subFolderName + "\')");
                endpointRequest.Method = "POST";
                //endpointRequest.Headers.Add("binaryStringRequestBody", "true");
                endpointRequest.Headers.Add("Authorization", "Bearer " + accessToken);
                endpointRequest.Headers.Add("X-RequestDigest", formDigest);
                endpointRequest.ContentType = "application/json; charset=utf-8";

                endpointRequest.ContentLength = 0;
                endpointRequest.Credentials = System.Net.CredentialCache.DefaultCredentials;

                //endpointRequest.GetRequestStream().Write(fileData, 0, fileData.Length);

                HttpWebResponse endpointresponse = (HttpWebResponse)endpointRequest.GetResponse();

                isFileUploaded = true;

            }
            catch (Exception ex)
            {
                isFileUploaded = false;
                string guid = WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format("An error occurred while reading data. GUID: {0}", guid));
            }

            return isFileUploaded;

        }

        public static bool CreateListFolder(string siteUrl, string errorLogPath, string accessToken, string listUrl, string rootFolderName, string subFolderName, bool overwrite, XmlNamespaceManager xmlnspm, XmlNode formDigestNode)
        {
            bool isFileUploaded = false;
            try
            {
                string formDigest = formDigestNode.InnerXml;
                //string entityTypeName = GetEntityTypeName(siteUrl, listUrl, xmlnspm);
                ///string entityTypeName = "{ '__metadata': { 'type': 'SP.Folder' }, 'ServerRelativeUrl': '/Candidate Master/folderq'}";

                HttpWebRequest endpointRequest;
                endpointRequest = (HttpWebRequest)HttpWebRequest.Create(siteUrl + "/_api/web/Lists/GetByTitle('" + "Candidate Master" + "')" + "/rootfolder/folders/add(url=\'" + subFolderName + "\')");
                endpointRequest.Method = "POST";
                endpointRequest.Headers.Add("Authorization", "Bearer " + accessToken);
                endpointRequest.Headers.Add("X-RequestDigest", formDigest);
                endpointRequest.ContentType = "application/json;odata=verbose";
                endpointRequest.Accept = "application/json;odata=verbose";

                endpointRequest.ContentLength = 0;
                endpointRequest.Credentials = System.Net.CredentialCache.DefaultCredentials;

                HttpWebResponse endpointresponse = (HttpWebResponse)endpointRequest.GetResponse();
                isFileUploaded = true;

            }
            catch (Exception ex)
            {
                isFileUploaded = false;
                string guid = WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format("An error occurred while reading data. GUID: {0}", guid));
            }

            return isFileUploaded;

        }

        public static string AddListItemsFolder(string siteUrl, string errorLogPath, string accessToken, string listUrl, string listItemUrl, string itemPostBody, XmlNamespaceManager xmlnspm, XmlNode formDigestNode)
        {
            try
            {
                string FormDigest = formDigestNode.InnerXml;
                string EntityTypeName = GetEntityTypeName(siteUrl, listUrl, xmlnspm);
                itemPostBody = "{'__metadata':{'type':'SP.Data.Candidate_x0020_MasterListItem'},'Title':'C6145441003','FolderServerRelativeUrl': '/sites/rms/Lists/Candidate%20Master/2016_May'}";
                //itemPostBody = itemPostBody.Replace("{0}", EntityTypeName);
                Byte[] itemPostData = System.Text.Encoding.ASCII.GetBytes(itemPostBody);

                HttpWebRequest ItemRequest =
                        (HttpWebRequest)HttpWebRequest.Create(siteUrl + listItemUrl);
                ItemRequest.Method = "POST";
                ItemRequest.ContentLength = itemPostBody.Length;
                ItemRequest.ContentType = "application/json;odata=verbose";
                ItemRequest.Accept = "application/json;odata=verbose";
                ItemRequest.Headers.Add("Authorization", "Bearer " + accessToken);
                ItemRequest.Credentials = System.Net.CredentialCache.DefaultCredentials;

                ItemRequest.Headers.Add("X-RequestDigest", FormDigest);
                using (Stream itemRequestStream = ItemRequest.GetRequestStream())
                {
                    itemRequestStream.Write(itemPostData, 0, itemPostData.Length);
                    //itemRequestStream.Close();
                }

                HttpWebResponse itemResponse = (HttpWebResponse)ItemRequest.GetResponse();
                return null;
            }
            catch (Exception ex)
            {
                string guid = WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format("An error occurred while reading data. GUID: {0}", guid));
            }

        }
        
        /// <summary>
        /// Update Meta data of Files in Document library
        /// </summary>
        /// <param name="siteUrl"></param>
        /// <param name="errorLogPath"></param>
        /// <param name="accessToken"></param>
        /// <param name="listUrl"></param>
        /// <param name="rootFolderName"></param>
        /// <param name="subFolderName"></param>
        /// <param name="FileName"></param>
        /// <param name="itemPostBody"></param>
        /// <param name="docLibraryUrl"></param>
        /// <returns></returns>
        public static bool UpdateMetadata(string siteUrl, string errorLogPath, string accessToken, string listUrl, string rootFolderName, string fileName, string internalFileName, string itemPostBody, string docLibraryUrl, XmlNamespaceManager xmlnspm, XmlNode formDigestNode, string userID)
        {
            bool isFileUploaded = false;
            try
            {
                itemPostBody = itemPostBody.TrimEnd('}');
                itemPostBody = itemPostBody + ",'CreatedById':" + userID + ",'ModifiedById':" + userID + "}";
                string formDigest = formDigestNode.InnerXml;
                string entityTypeName = GetEntityTypeName(siteUrl, docLibraryUrl, xmlnspm);
                itemPostBody = itemPostBody.Replace("{0}", entityTypeName);
                itemPostBody = itemPostBody.Replace("{1}", fileName);
                Byte[] itemPostData = System.Text.Encoding.ASCII.GetBytes(itemPostBody);


                HttpWebRequest endpointRequest;
                endpointRequest = (HttpWebRequest)HttpWebRequest.Create(siteUrl + "/_api/web/GetFolderByServerRelativeUrl('" + listUrl + "/" + rootFolderName + "')/Files('" + internalFileName + "')/ListItemAllFields");
                endpointRequest.Method = "POST";

                endpointRequest.Headers.Add("X-HTTP-Method", "MERGE");
                endpointRequest.Headers.Add("IF-MATCH", "*");
                endpointRequest.ContentLength = itemPostBody.Length;
                endpointRequest.ContentType = "application/json;odata=verbose";
                endpointRequest.Accept = "application/json;odata=verbose";
                endpointRequest.Headers.Add("Authorization", "Bearer " + accessToken);
                endpointRequest.Credentials = System.Net.CredentialCache.DefaultCredentials;
                endpointRequest.Headers.Add("X-RequestDigest", formDigest);
                using (Stream itemRequestStream = endpointRequest.GetRequestStream())
                {
                    itemRequestStream.Write(itemPostData, 0, itemPostData.Length);
                    //itemRequestStream.Close();
                }
                HttpWebResponse itemResponse = (HttpWebResponse)endpointRequest.GetResponse();

                //Update Folder Path in Candidate Master
                isFileUploaded = true;

            }
            catch (Exception ex)
            {
                isFileUploaded = false;
                string guid = WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format("An error occurred while reading data. GUID: {0}", guid));
            }

            return isFileUploaded;

        }

        public static Stream RetrieveFileViaREST(string fileUrl)
        {
            HttpWebRequest request = null;
            string commandString = string.Empty;
            commandString = fileUrl;

            Uri uri = new Uri(commandString);

            //Set up the HTTP Request -- ASSUMING YOU ARE USING NTLM -- IF NOT THEN PASS IN THE CORRECT CREDENTIALS
            request = (HttpWebRequest)WebRequest.Create(uri);
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Method = WebRequestMethods.Http.Get;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.ContentLength > 0) response.ContentLength = response.ContentLength;
            return response.GetResponseStream();

        }

        public static StreamReader RetrieveFileStreamReaderViaREST(string fileUrl)
        {
            HttpWebRequest request = null;
            string commandString = string.Empty;
            commandString = fileUrl;

            Uri uri = new Uri(commandString);

            //Set up the HTTP Request -- ASSUMING YOU ARE USING NTLM -- IF NOT THEN PASS IN THE CORRECT CREDENTIALS
            request = (HttpWebRequest)WebRequest.Create(uri);
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Method = WebRequestMethods.Http.Get;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.ContentLength > 0) response.ContentLength = response.ContentLength;
            return new StreamReader(response.GetResponseStream());
        }

        public static byte[] RetrieveFileByteViaREST(string fileUrl)
        {
            //HttpResponse response = HttpContext.Current.Response;
            //response.Clear();
            //response.ClearContent();
            //response.ClearHeaders();
            //response.Buffer = true;
            byte[] buffer = new byte[2048];
            byte[] data;
            Uri uri = new Uri(fileUrl);

            WebRequest request = WebRequest.Create(uri);
            request.Credentials = CredentialCache.DefaultCredentials;
            using (WebResponse response = request.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        int count = 0;
                        do
                        {
                            count = responseStream.Read(buffer, 0, buffer.Length);
                            ms.Write(buffer, 0, count);
                        } while (count != 0);
                        data = ms.ToArray();
                    }
                }
            }

            return data;
            //HttpWebRequest request = null;
            //HttpWebResponse response = null;
            //string commandString = string.Empty;
            //commandString = fileUrl;

            //Uri uri = new Uri(commandString);

            ////Set up the HTTP Request -- ASSUMING YOU ARE USING NTLM -- IF NOT THEN PASS IN THE CORRECT CREDENTIALS
            //request = (HttpWebRequest)WebRequest.Create(uri);
            //request.Credentials = CredentialCache.DefaultCredentials;
            //request.Method = WebRequestMethods.Http.Get;

            //response = (HttpWebResponse)request.GetResponse();
            //if (response.ContentLength > 0) response.ContentLength = response.ContentLength;
            //Stream output = response.GetResponseStream();
            //return output;
        }

        public static string DeleteListItems(string siteUrl, string errorLogPath, string accessToken, string listUrl, string listItemUrl, string id)
        {
            try
            {
                XmlNamespaceManager xmlnspm = AddXmlNameSpaces();
                var formDigestNode = GetFormDigest(siteUrl, accessToken, xmlnspm);

                string FormDigest = formDigestNode.InnerXml;
                // string EntityTypeName = GetEntityTypeName(siteUrl, listUrl, xmlnspm);
                HttpWebRequest ItemRequest =
                        (HttpWebRequest)HttpWebRequest.Create(siteUrl + listItemUrl + "(" + id + ")");
                ItemRequest.Method = "POST";
                ItemRequest.Headers.Add("X-HTTP-Method", "DELETE");
                ItemRequest.Headers.Add("IF-MATCH", "*");
                ItemRequest.Headers.Add("Authorization", "Bearer " + accessToken);
                ItemRequest.Credentials = System.Net.CredentialCache.DefaultCredentials;

                ItemRequest.Headers.Add("X-RequestDigest", FormDigest);
                using (Stream itemRequestStream = ItemRequest.GetRequestStream())
                {
                    //itemRequestStream.Close();
                }
                HttpWebResponse itemResponse = (HttpWebResponse)ItemRequest.GetResponse();
                return null;
            }
            catch (Exception ex)
            {
                string guid = WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format("An error occurred while reading data. GUID: {0}", guid));
            }

        }

        /// <summary>
        /// Add Namespaces to Xmlnode
        /// </summary>
        /// <returns></returns>
        public static XmlNamespaceManager AddXmlNameSpaces()
        {

            try
            {
                XmlNamespaceManager xmlnspm = new XmlNamespaceManager(new NameTable());

                xmlnspm.AddNamespace("atom", "http://www.w3.org/2005/Atom");
                xmlnspm.AddNamespace("d", "http://schemas.microsoft.com/ado/2007/08/dataservices");
                xmlnspm.AddNamespace("m", "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata");
                return xmlnspm;

            }
            catch (Exception ex)
            {
                string guid = WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format("An error occurred while reading data. GUID: {0}", guid));
            }
        }

        /// <summary>
        /// Get entity type name 
        /// </summary>
        /// <param name="siteUrl"></param>
        /// <param name="listUrl"></param>
        /// <param name="xmlnspm"></param>
        /// <returns></returns>
        public static string GetEntityTypeName(string siteUrl, string listUrl, XmlNamespaceManager xmlnspm)
        {
            string entitytypeName = string.Empty;
            try
            {
                HttpWebRequest listRequest =
                    (HttpWebRequest)HttpWebRequest.Create(siteUrl + listUrl);
                listRequest.Method = "GET";
                listRequest.Accept = "application/atom+xml";
                listRequest.ContentType = "application/atom+xml;type=entry";
                listRequest.Credentials = System.Net.CredentialCache.DefaultCredentials;
                HttpWebResponse listResponse = (HttpWebResponse)listRequest.GetResponse();
                using (StreamReader listReader = new StreamReader(listResponse.GetResponseStream()))
                {
                    var listXml = new XmlDocument();
                    listXml.LoadXml(listReader.ReadToEnd());
                    var entityTypeNode = listXml.SelectSingleNode("//atom:entry/atom:content/m:properties/d:ListItemEntityTypeFullName", xmlnspm);
                    var listNameNode = listXml.SelectSingleNode("//atom:entry/atom:content/m:properties/d:Title", xmlnspm);
                    entitytypeName = entityTypeNode.InnerXml;
                }

            }
            catch (Exception ex)
            {
                string guid = WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format("An error occurred while reading data. GUID: {0}", guid));
            }
            return entitytypeName;
        }

        public static Claim TryGetClaim(string key)
        {
            try
            {
                var identity = HttpContext.Current.Request.RequestContext.HttpContext.User.Identity as ClaimsIdentity;
                if (identity != null)
                    return identity.Claims.FirstOrDefault(o => o.Type.Equals(key));
                else
                    return null;
            }
            catch (Exception ex)
            {
                string guid = WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format("An error occurred while reading data. GUID: {0}", guid));
            }
        }
    }
}
