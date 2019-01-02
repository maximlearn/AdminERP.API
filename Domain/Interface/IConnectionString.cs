using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interface
{
   public  interface IConnectionString
    {
         string TargetDatabaseConnectionString { get; }
        string TargetDocumentDatabaseConnectionString { get; }

    }
}
