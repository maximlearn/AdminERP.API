using System;
using System.Collections.Generic;

namespace DataEntities.AdminERPContext.Models
{
    public partial class UserCredential
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Password { get; set; }
        public string PasswordKey { get; set; }
        public int? Attempted { get; set; }

        public virtual User User { get; set; }
    }
}
