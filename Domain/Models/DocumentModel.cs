using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
   public class DocumentModel
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
}
