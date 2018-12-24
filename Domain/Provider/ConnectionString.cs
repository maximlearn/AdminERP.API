using Domain.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Provider
{
   public  class ConnectionString : IConnectionString
    {
        private readonly IConfiguration configuration;

        public ConnectionString(IConfiguration _configuration)
        {
            this.configuration = _configuration;
        }

        public string TargetDatabaseConnectionString => this.configuration.GetConnectionString("TargetDatabase");
    }
}
