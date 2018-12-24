using System;
using System.Collections.Generic;

namespace DataEntities.AdminERPContext.Models
{
    public partial class SecurityQuestion
    {
        public SecurityQuestion()
        {
            UserSecurityAnswer = new HashSet<UserSecurityAnswer>();
        }

        public int Id { get; set; }
        public string Question { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<UserSecurityAnswer> UserSecurityAnswer { get; set; }
    }
}
