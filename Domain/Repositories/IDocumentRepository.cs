﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repositories
{
   public interface IDocumentRepository
    {
        Boolean SaveDocument(DocumentModel document);
        DocumentModel GetDocumentById(string documentId);
    }
}
