using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class CouchDBDocument
    {
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string FileLable { get; set; }
        public string DocumentType { get; set; }
        public string DocumentId { get; set; }
        public string DocumentNo { get; set; }
        public string Keyword { get; set; }
        public string Description { get; set; }
        public string DocumentCategory { get; set; }
        public byte[] FileImage { get; set; }
    }

    public class CouchDBSaveResponse
    {
        public string ok { get; set; }
        public string id { get; set; }
        public object rev { get; set; }
    }

    public class CouchDBGetResponse
    {
        public string content_type { get; set; }
        public int revpos { get; set; }
        public string digest { get; set; }
        public int length { get; set; }
        public bool stub { get; set; }
    }
}
