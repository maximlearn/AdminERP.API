using Domain.Models;
using Domain.Repositories;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementation
{
  public  class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository documentRepository;
        public DocumentService(IDocumentRepository _documentRepository)
        {
            documentRepository = _documentRepository;
        }

        public DocumentModel GetDocumentById(string documentId)
        {
            return documentRepository.GetDocumentById(documentId);
        }

        public Boolean SaveDocument(DocumentModel document)
        {
            return documentRepository.SaveDocument(document);
        }
    }
}
