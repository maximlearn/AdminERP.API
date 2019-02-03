using Domain.Interface;
using Domain.Models;
using Domain.Repositories;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Text;

namespace Repositories.DocumentRepository
{
   public class DocumentRepository : IDocumentRepository
    {
        private readonly IConnectionString connectionString;
        public DocumentRepository(IConnectionString _connectionString)
        {
            connectionString = _connectionString;
        }

        public Boolean SaveDocument(DocumentModel document)
        {
            //CouchDBDocument objDocument = new CouchDBDocument();
            //objDocument.FileImage = documentModel.FileImage;
            //objDocument.FileName = documentModel.FileName;
            //objDocument.DocumentType = documentModel.FileType;
            //objDocument.DocumentId = documentModel.DocumentNo;


            bool _success = false;
            //try
            //{
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(this.connectionString.TargetDocumentDatabaseConnectionString);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                Stream streams = new MemoryStream(document.FileImage);
                MemoryStream memoryStream = new MemoryStream();
                streams.CopyTo(memoryStream);
                string baseStr64 = Convert.ToBase64String(memoryStream.ToArray());

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    List<string> lst = new List<string>() { "DocumentType", "DocumentNo", "Keyword", "Description", "DocumentCategory" };

                    var json = "{\"_id\":\"" + document.DocumentId + "\",";

                    string strvalue = string.Empty;

                    foreach (var Node in lst)
                    {
                        switch (Node.ToLower())
                        {
                            case "documenttype":
                                strvalue = document.DocumentType;
                                break;
                            case "documentno":
                                strvalue = document.DocumentNo;
                                break;
                            case "keyword":
                                strvalue = document.Keyword;
                                break;
                            case "description":
                                strvalue = document.Description;
                                break;
                            case "documentcategory":
                                strvalue = document.DocumentCategory;
                                break;
                        }
                        json += "\"" + Node.ToString() + "\":\"" + strvalue + "\",";
                    }

                    string json1 = string.Empty;

                    json1 += json + "\"_attachments\":{\"" + document.FileName + "\":{ \"content_type\":\"" + document.FileType + "\",\"data\": \"" + baseStr64 + "\"}" + "}" + "}";

                    streamWriter.WriteLine(json1);
                    streamWriter.Flush();
                    streamWriter.Close();
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        var response = JsonConvert.DeserializeObject<CouchDBSaveResponse>(result);
                        if (response.ok.ToLower() == "true")
                        {
                            _success = true;
                        }
                    }
                }
           // }
            //catch
            //{
            //    _success = false;
            //   // throw; log the error
            //}
            return _success;

        }


        public DocumentModel GetDocumentById(string documentId)
        {

            //DataSet dsResult = new DataSet();
            //dsResult.Tables.Add("DataSet");
            DocumentModel documentModel = new DocumentModel();
           
            try
            {
                //bool rtbndeleted = false;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.connectionString.TargetDocumentDatabaseConnectionString + "/" + documentId);
               // (HttpWebRequest)WebRequest.Create(strCouchDBUri + "/" + strCouchDBName + "/" + param.ExternalDocumentId);
                request.ContentType = "application/json";
                request.Method = "get";
                var responseString = "";
                if (!string.IsNullOrWhiteSpace(documentId))
                {
                  //  dsResult.Tables[0].Columns.Add("FileName");
                   // dsResult.Tables[0].Columns.Add("FileType");
                   // dsResult.Tables[0].Columns.Add("FileImage", typeof(byte[]));

                    var response = (HttpWebResponse)request.GetResponse();
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                        var Json = responseString;
                        JObject jsonResponse = JObject.Parse(responseString);
                        JObject objResponse = JObject.Parse(jsonResponse["_attachments"].ToString());
                        string strFileLabel = jsonResponse["Description"].ToString();
                        string strFileType = jsonResponse["DocumentType"].ToString(); ;//ContentType
                        JToken t1 = objResponse.First;
                        string strFileValue = ((JProperty)t1).Value.ToString();
                        var responseCouchDB = JsonConvert.DeserializeObject<CouchDBGetResponse>(strFileValue);

                        //dealing first attachment..........
                        string strFileName = ((JProperty)t1).Name.ToString();
                       string strContentType = t1.First["content_type"].ToString();
                       
                        byte[] byteArrays = null;

                        var requestGetFile = (HttpWebRequest)WebRequest.Create(this.connectionString.TargetDocumentDatabaseConnectionString + "/" + documentId + "/" + strFileName);
                        //(HttpWebRequest)WebRequest.Create(strCouchDBUri + "/" + strCouchDBName + "/" + param.ExternalDocumentId + "/" + strFileName);
                        requestGetFile.Method = "get";
                        try
                        {
                            var responseGetFile = (HttpWebResponse)requestGetFile.GetResponse();
                            MemoryStream ms = new MemoryStream();
                            responseGetFile.GetResponseStream().CopyTo(ms);
                            byteArrays = ms.ToArray();
                            ms.Close();
                        }
                        catch { }

                        //dsResult.Tables[0].Rows.Add();
                        documentModel.FileName = strFileName;
                        documentModel.FileType = strFileType;
                        documentModel.FileLabel = strFileLabel;
                        documentModel.FileImage = byteArrays;
                        //if (strFileType.Contains("image"))
                        //{ d }


                       
                    }
                }
            }
            catch
            {
                throw;
            }
            return documentModel;
        }

        

        /// <summary>
        /// For Couch db
        /// </summary>
        /// <param name="id"></param>
        /// <param name="strCouchDBuri"></param>
        /// <returns></returns>
        //private static string GetCommonCouchDB(String id,string conString)
        //{
        //    var request = (HttpWebRequest)WebRequest.Create(conString);
        //    request.Method = "get";
        //    var responseString = "";
        //    try
        //    {
        //        var response = (HttpWebResponse)request.GetResponse();
        //        responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.Message.Contains("404")) return "";
        //    }
        //    return responseString;
        //}

        ///// <summary>
        ///// Use for Delete External Document from database.
        ///// </summary>
        ///// <param name="param"></param>
        ///// <returns></returns>
        //public bool DeleteDataCouchDB(MExternalDocument.ExternalDocument param)
        //{
        //    bool _success = false;
        //    try
        //    {
        //        string revision = "";
        //        var response = GetCommonCouchDB(param.ExternalDocumentId.ToString(),this.connectionString.TargetDocumentDatabaseConnectionString);

        //        if (response != "")
        //        {
        //            Predicate<string> findRevision = (string attribute) => { return attribute.Contains("_rev"); };
        //            revision = Array.Find<string>(response.Split(','), findRevision).Split(':')[1].Trim('"');
        //        }

        //        var request = (HttpWebRequest)WebRequest.Create(this.connectionString.TargetDocumentDatabaseConnectionString + "/" + param.ExternalDocumentId + "?rev=" + revision);
        //        request.Method = "DELETE";

        //        try
        //        {
        //            var responseDelete = (HttpWebResponse)request.GetResponse();
        //        }
        //        catch
        //        {
        //            _success = false;
        //        }
        //        _success = true;
        //    }
        //    catch
        //    {
        //        _success = false;
        //        throw;
        //    }
        //    return _success;
        //}
    }
}
